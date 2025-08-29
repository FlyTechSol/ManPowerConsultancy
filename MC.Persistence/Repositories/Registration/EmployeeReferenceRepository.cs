
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

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
                UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
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
