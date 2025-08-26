using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class FamilyRepository : GenericRepository<Family>, IFamilyRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public FamilyRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<FamilyDetailDto?> GetAllFamilyByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.Famlies
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .Select(ex => new FamilyDetailDto
                {
                    Id = ex.Id,
                    UserProfileId = ex.UserProfileId,
                    UserProfileName = ex.UserProfile != null ? ex.UserProfile.FirstName + " " + ex.UserProfile.LastName : string.Empty,
                    Name = ex.Name,
                    Relationship = ex.Relationship,
                    IsPFNominee = ex.IsPFNominee,
                    PFPercentage = ex.PFPercentage,
                    DateOfBirth = ex.DateOfBirth,
                    Address = ex.Address,
                    RelationTo = ex.RelationTo,
                    IsMinor = ex.IsMinor,
                    IsDependent = ex.IsDependent,
                    IsResidingWithEmployee = ex.IsResidingWithEmployee,
                    IsActive = ex.IsActive,
                    DateCreated = Helper.DateHelper.FormatDate(ex.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(ex.DateModified),
                    CreatedByName = Helper.UserHelper.GetFormattedName(ex.CreatedByUser),
                    ModifiedByName = Helper.UserHelper.GetFormattedName(ex.ModifiedByUser),
                })
                .FirstOrDefaultAsync(cancellationToken);
            return response;
        }

        public async Task<FamilyDetailDto?> GetFamilyByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Famlies
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            var dto = new FamilyDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
                Name = response.Name,
                Relationship = response.Relationship,
                IsPFNominee = response.IsPFNominee,
                PFPercentage = response.PFPercentage,
                DateOfBirth = response.DateOfBirth,
                Address = response.Address,
                RelationTo = response.RelationTo,
                IsMinor = response.IsMinor,
                IsDependent = response.IsDependent,
                IsResidingWithEmployee = response.IsResidingWithEmployee,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = Helper.UserHelper.GetFormattedName(response.CreatedByUser),
                ModifiedByName = Helper.UserHelper.GetFormattedName(response.ModifiedByUser),
            };
            return dto;
        }
    }
}
