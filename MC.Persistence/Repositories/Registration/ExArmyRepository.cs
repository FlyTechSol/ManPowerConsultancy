using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Registration
{
    public class ExArmyRepository : GenericRepository<ExArmy>, IExArmyRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public ExArmyRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
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
