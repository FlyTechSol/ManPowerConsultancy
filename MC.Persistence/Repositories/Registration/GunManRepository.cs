using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class GunManRepository : GenericRepository<GunMan>, IGunManRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public GunManRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<GunManDetailDto?> GetAllGunMenByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.GunMen
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .Select(ex => new GunManDetailDto
                {
                    Id = ex.Id,
                    UserProfileId = ex.UserProfileId,
                    UserProfileName = ex.UserProfile != null ? ex.UserProfile.FirstName + " " + ex.UserProfile.LastName : string.Empty,
                    GunLicenceName = ex.GunLicenceName,
                    GunLicenseNumber = ex.GunLicenseNumber,
                    WeaponNumber = ex.WeaponNumber,
                    WeaponType = ex.WeaponType,
                    MakeOfCompany = ex.MakeOfCompany,
                    GunLicenseIssuedBy = ex.GunLicenseIssuedBy,
                    GunLicenseIssuedDate = ex.GunLicenseIssuedDate,
                    GunLicenseExpiryDate = ex.GunLicenseExpiryDate,
                    GunLicenseRemarks = ex.GunLicenseRemarks,
                    Jurisdiction = ex.Jurisdiction,
                    LicenceAddress = ex.LicenceAddress,
                    IsActive = ex.IsActive,
                    DateCreated = Helper.DateHelper.FormatDate(ex.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(ex.DateModified),
                    CreatedByName = Helper.UserHelper.GetFormattedName(ex.CreatedByUser),
                    ModifiedByName = Helper.UserHelper.GetFormattedName(ex.ModifiedByUser),
                })
                .FirstOrDefaultAsync(cancellationToken);
            return response;
        }

        public async Task<GunManDetailDto?> GetGunManByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.GunMen
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            var dto = new GunManDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
                GunLicenceName = response.GunLicenceName,
                GunLicenseNumber = response.GunLicenseNumber,
                WeaponNumber = response.WeaponNumber,
                WeaponType = response.WeaponType,
                MakeOfCompany = response.MakeOfCompany,
                GunLicenseIssuedBy = response.GunLicenseIssuedBy,
                GunLicenseIssuedDate = response.GunLicenseIssuedDate,
                GunLicenseExpiryDate = response.GunLicenseExpiryDate,
                GunLicenseRemarks = response.GunLicenseRemarks,
                Jurisdiction = response.Jurisdiction,
                LicenceAddress = response.LicenceAddress,
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
