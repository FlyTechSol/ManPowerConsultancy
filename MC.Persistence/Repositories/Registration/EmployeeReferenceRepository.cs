
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
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

        public async Task<EmployeeReferenceDetailDto?> GetAllEmpRefByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.EmployeeReferences
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .Select(ex => new EmployeeReferenceDetailDto
                {
                    Id = ex.Id,
                    UserProfileId = ex.UserProfileId,
                    UserProfileName = ex.UserProfile != null ? ex.UserProfile.FirstName + " " + ex.UserProfile.LastName : string.Empty,
                    EmployeeName = ex.EmployeeName,
                    EmployeeDesignation = ex.EmployeeDesignation,
                    EmployeeDepartment = ex.EmployeeDepartment,
                    EmployeeContactNumber = ex.EmployeeContactNumber,
                    EmployeeEmail = ex.EmployeeEmail,
                    EmployeeAddress = ex.EmployeeAddress,
                    EmployeeRelationship = ex.EmployeeRelationship,
                    IsActive = ex.IsActive,
                    Remarks = ex.Remarks,
                    DateCreated = Helper.DateHelper.FormatDate(ex.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(ex.DateModified),
                    CreatedByName = Helper.UserHelper.GetFormattedName(ex.CreatedByUser),
                    ModifiedByName = Helper.UserHelper.GetFormattedName(ex.ModifiedByUser),
                })
                .FirstOrDefaultAsync(cancellationToken);
            return response;
        }

        public async Task<EmployeeReferenceDetailDto?> GetEmpRefByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.EmployeeReferences
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            var dto = new EmployeeReferenceDetailDto
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
                CreatedByName = Helper.UserHelper.GetFormattedName(response.CreatedByUser),
                ModifiedByName = Helper.UserHelper.GetFormattedName(response.ModifiedByUser),
            };
            return dto;
        }
    }
}
