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
    public class EmployeeReferenceRepository : GenericRepository<EmployeeReference>, IEmployeeReferenceRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public EmployeeReferenceRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<List<EmployeeReferenceDetailDto>?> GetAllEmpRefByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.EmployeeReferences
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<EmployeeReferenceDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }

        public async Task<PaginatedResponse<EmployeeReferenceDetailDto>?> GetAllEmployeesByUserProfileIdAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.EmployeeReferences
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfileId && !ex.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    (q.EmployeeName.ToLower().Contains(search)) ||
                    !string.IsNullOrWhiteSpace(q.EmployeeDesignation) && q.EmployeeDesignation.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.EmployeeDepartment) && q.EmployeeDepartment.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.EmployeeContactNumber) && q.EmployeeContactNumber.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.EmployeeEmail) && q.EmployeeEmail.ToLower().Contains(search) 
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
                query = query.OrderBy(a => a.EmployeeName); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<EmployeeReferenceDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        public async Task<List<EmployeeReferenceDetailDto>?> GetAllEmpRefByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _context.EmployeeReferences
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfileId && !ex.IsDeleted)
                .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<EmployeeReferenceDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<EmployeeReferenceDetailDto?> GetEmpRefByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.EmployeeReferences
                .AsNoTracking()
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        private EmployeeReferenceDetailDto MapToDto(Domain.Entity.Registration.EmployeeReference response)
        {
            return new EmployeeReferenceDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                //UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
                EmployeeName = response.EmployeeName,
                EmployeeDesignation = response.EmployeeDesignation,
                EmployeeDepartment = response.EmployeeDepartment,
                EmployeeContactNumber = response.EmployeeContactNumber,
                EmployeeEmail = response.EmployeeEmail,
                EmployeeAddress = response.EmployeeAddress,
                EmployeeRelationship = response.EmployeeRelationship,
                IsActive = response.IsActive,
                Remarks = response.Remarks,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
