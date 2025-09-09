using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Registration
{
    public class InsuranceNomineeRepository : GenericRepository<InsuranceNominee>, IInsuranceNomineeRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public InsuranceNomineeRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<PaginatedResponse<InsuranceNomineeDetailDto>?> GetAllDetailsAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.InsuranceNominees
                .AsNoTracking()
                .Where(addr => addr.UserProfileId == userProfileId && !addr.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                     q.NominatedBy.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.NomineeName) && q.NomineeName.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.RelationWithNominee) && q.RelationWithNominee.ToLower().Contains(search)
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
                query = query.OrderBy(a => a.NominatedBy); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<InsuranceNomineeDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        public async Task<List<InsuranceNomineeDetailDto>?> GetAllInsuranceNomineeByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.InsuranceNominees
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<InsuranceNomineeDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<List<InsuranceNomineeDetailDto>?> GetAllInsuranceNomineeByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _context.InsuranceNominees
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfileId && !ex.IsDeleted)
                .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<InsuranceNomineeDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<InsuranceNomineeDetailDto?> GetInsuranceNomineeByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.InsuranceNominees
                .AsNoTracking()
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        private InsuranceNomineeDetailDto MapToDto(Domain.Entity.Registration.InsuranceNominee response)
        {
            return new InsuranceNomineeDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                //UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
                NominatedBy = response.NominatedBy,
                NominatedByFather = response.NominatedByFather,
                SoldierNumber = response.SoldierNumber,
                SoldierRank = response.SoldierRank,
                SoldierUnit = response.SoldierUnit,
                NominatedByDoB = response.NominatedByDoB,
                NominatedByPermanentAddress = response.NominatedByPermanentAddress,
                NominatedByCorrespondenceAddress = response.NominatedByCorrespondenceAddress,
                NomineeName = response.NomineeName,
                RelationWithNominee = response.RelationWithNominee,
                NomineeFather = response.NomineeFather,
                NomineeDoB = response.NomineeDoB,
                NomineeByPermanentAddress = response.NomineeByPermanentAddress,
                NomineeByCorrespondenceAddress = response.NomineeByCorrespondenceAddress,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}