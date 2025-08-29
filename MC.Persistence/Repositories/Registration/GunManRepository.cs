using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
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

        public async Task<List<GunManDetailDto>?> GetAllGunMenByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.GunMen
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<GunManDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<List<GunManDetailDto>?> GetAllGunMenByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _context.GunMen
              .AsNoTracking()
              .Where(ex => ex.UserProfileId == userProfileId && !ex.IsDeleted)
              .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<GunManDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<GunManDetailDto?> GetGunManByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.GunMen
                .AsNoTracking()
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        private GunManDetailDto MapToDto(Domain.Entity.Registration.GunMan response)
        {
            return new GunManDetailDto
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
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
