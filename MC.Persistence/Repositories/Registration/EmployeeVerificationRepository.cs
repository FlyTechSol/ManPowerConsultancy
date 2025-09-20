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
    public class EmployeeVerificationRepository : GenericRepository<EmployeeVerification>, IEmployeeVerificationRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IFileUploadRepository _fileUploadRepository;
        public EmployeeVerificationRepository(IUserProfileRepository userProfileRepository, IFileUploadRepository fileUploadRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
            _fileUploadRepository = fileUploadRepository;
        }

        public async Task<PaginatedResponse<EmployeeVerificationDetailDto>?> GetEmployeeVerificationByUserProfileIdAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.EmployeeVerifications
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfileId && !ex.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    (q.AgencyName.ToLower().Contains(search)) ||
                    (q.VerificationType.ToString().ToLower().Contains(search)) ||
                    (q.Status.ToString().ToLower().Contains(search)) ||
                    (q.Result.ToString().ToLower().Contains(search))
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
                query = query.OrderBy(a => a.AgencyName); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<EmployeeVerificationDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
       
        public async Task<EmployeeVerificationDetailDto?> GetEmployeeVerificationByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.EmployeeVerifications
                .AsNoTracking()
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<Guid> CreateEmployeeVerificationAsync(MC.Domain.Entity.Registration.EmployeeVerification request, IFormFile? agencyCertificateUrl, CancellationToken cancellationToken)
        {
            // start a transaction on your existing context
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                request.IsActive = true;

                // first save to generate Id
                _context.EmployeeVerifications.Add(request);
                await _context.SaveChangesAsync(cancellationToken);

                if (agencyCertificateUrl != null)
                {
                    // upload file first (to disk)
                    var url = await _fileUploadRepository
                        .UploadFileAsync(agencyCertificateUrl, "ExArmyCertificate", false, cancellationToken);

                    // update DB with file path
                    request.AgencyReportUrl = url;
                    _context.EmployeeVerifications.Update(request);
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

        public async Task<Guid> UpdateEmployeeVerificationAsync(MC.Domain.Entity.Registration.EmployeeVerification request, IFormFile? agencyCertificateUrl, CancellationToken cancellationToken)
        {
            var existing = await _context.EmployeeVerifications
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (existing == null)
                throw new NotFoundException($"Employee verification with Id {request.Id} not found", request.Id);

            //existing.UserId = userProfile.UserId;
            existing.VerificationType = request.VerificationType;
            existing.AgencyName = request.AgencyName;
            existing.InitiatedDate = request.InitiatedDate;
            existing.Status = request.Status;
            existing.IsActive = request.IsActive;

            if (agencyCertificateUrl != null)
            {
                // (optional) delete old file to avoid orphan files
                if (!string.IsNullOrWhiteSpace(existing.AgencyReportUrl) &&
                    System.IO.File.Exists(existing.AgencyReportUrl))
                {
                    System.IO.File.Delete(existing.AgencyReportUrl);
                }

                var url = await _fileUploadRepository.UploadFileAsync(agencyCertificateUrl, "AgencyCertificate", false, cancellationToken);
                existing.AgencyReportUrl = url;
            }

            _context.EmployeeVerifications.Update(existing);
            await _context.SaveChangesAsync(cancellationToken);

            return existing.Id;
        }
        private EmployeeVerificationDetailDto MapToDto(Domain.Entity.Registration.EmployeeVerification response)
        {
            return new EmployeeVerificationDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                VerificationType = response.VerificationType,
                AgencyName = response.AgencyName,
                InitiatedDate = response.InitiatedDate,
                CompletedDate = response.CompletedDate,
                Status = response.Status,
                Result = response.Result,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
