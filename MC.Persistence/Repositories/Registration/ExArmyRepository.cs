using MC.Application.Contracts.Persistence.FileHandling.Upload;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Registration
{
    public class ExArmyRepository : GenericRepository<ExArmy>, IExArmyRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IFileUploadRepository _fileUploadRepository;
        public ExArmyRepository(IUserProfileRepository userProfileRepository, IFileUploadRepository fileUploadRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
            _fileUploadRepository = fileUploadRepository;
        }

        public async Task<List<ExArmyDetailDto>?> GetAllExArmyByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.ExArmies
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<ExArmyDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }

        public async Task<PaginatedResponse<ExArmyDetailDto>?> GetExArmyByUserProfileIdAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.ExArmies
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfileId && !ex.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    (q.ServiceNumber != null && q.ServiceNumber.ToLower().Contains(search)) ||
                    (q.Rank != null && q.Rank.ToLower().Contains(search)) ||
                    (q.Unit != null && q.Unit.ToLower().Contains(search))
                );
            }

            // Total count before pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "";

                query = query.OrderBy($"{column} {direction}");
            }
            else
            {
                query = query.OrderBy(a => a.Rank); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<ExArmyDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        public async Task<List<ExArmyDetailDto>?> GetAllExArmyByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _context.ExArmies
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfileId && !ex.IsDeleted)
                .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<ExArmyDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<ExArmyDetailDto?> GetExArmyByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.ExArmies
                .AsNoTracking()
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<Guid> CreateExArmyAsync(ExArmy request, IFormFile? dischargeCertificateUrl, CancellationToken cancellationToken)
        {
            // start a transaction on your existing context
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                request.IsActive = true;

                // first save to generate Id
                _context.ExArmies.Add(request);
                await _context.SaveChangesAsync(cancellationToken);

                if (dischargeCertificateUrl != null)
                {
                    // upload file first (to disk)
                    var url = await _fileUploadRepository
                        .UploadFileAsync(dischargeCertificateUrl, "ExArmyCertificate", false, cancellationToken);

                    // update DB with file path
                    request.DischargeCertificateUrl = url;
                    _context.ExArmies.Update(request);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                // commit DB transaction
                await transaction.CommitAsync(cancellationToken);

                return request.Id;
            }
            catch
            {
                // roll back DB changes
                await transaction.RollbackAsync(cancellationToken);
                // optional: delete file if uploaded to avoid orphan files
                throw;
            }
        }

        public async Task<Guid> UpdateExArmyAsync(ExArmy request, IFormFile? dischargeCertificateUrl, CancellationToken cancellationToken)
        {
            var existing = await _context.ExArmies
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (existing == null)
                throw new NotFoundException($"Ex Army certificate with Id {request.Id} not found", request.Id);

            //existing.UserId = userProfile.UserId;
            existing.ServiceNumber = request.ServiceNumber;
            existing.Rank = request.Rank;
            existing.Unit = request.Unit;
            existing.BranchOfService = request.BranchOfService;
            existing.TotalService = request.TotalService;
            existing.EnlistmentDate = request.EnlistmentDate;
            existing.DischargeDate = request.DischargeDate;
            existing.ReasonForDischarge = request.ReasonForDischarge;
            existing.IsActive = request.IsActive;

            if (dischargeCertificateUrl != null)
            {
                // (optional) delete old file to avoid orphan files
                if (!string.IsNullOrWhiteSpace(existing.DischargeCertificateUrl) &&
                    System.IO.File.Exists(existing.DischargeCertificateUrl))
                {
                    System.IO.File.Delete(existing.DischargeCertificateUrl);
                }

                var url = await _fileUploadRepository.UploadFileAsync(dischargeCertificateUrl, "ExArmyCertificate", false, cancellationToken);
                existing.DischargeCertificateUrl = url;
            }

            _context.ExArmies.Update(existing);
            await _context.SaveChangesAsync(cancellationToken);

            return existing.Id;
        }
        private ExArmyDetailDto MapToDto(Domain.Entity.Registration.ExArmy response)
        {
            return new ExArmyDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
                ServiceNumber = response.ServiceNumber,
                Rank = response.Rank,
                Unit = response.Unit,
                BranchOfService = response.BranchOfService,
                TotalService = response.TotalService,
                EnlistmentDate = response.EnlistmentDate,
                DischargeDate = response.DischargeDate,
                ReasonForDischarge = response.ReasonForDischarge,
                DischargeCertificateUrl = response.DischargeCertificateUrl,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
