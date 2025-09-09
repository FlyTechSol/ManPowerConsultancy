using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class PoliceVerificationRepository : GenericRepository<PoliceVerification>, IPoliceVerificationRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public PoliceVerificationRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<PoliceVerificationDetailDto?> GetPoliceVerificationByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.PoliceVerifications
                .AsNoTracking()
                .Where(pv => pv.UserProfileId == userProfile.Id && !pv.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<PoliceVerificationDetailDto?> GetPoliceVerificationByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _context.PoliceVerifications
                .AsNoTracking()
                .Where(pv => pv.UserProfileId == userProfileId && !pv.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<PoliceVerificationDetailDto?> GetPoliceVerificationByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.PoliceVerifications
                .AsNoTracking()
                .Where(pv => pv.Id == id && !pv.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        private PoliceVerificationDetailDto MapToDto(Domain.Entity.Registration.PoliceVerification response)
        {
            return new PoliceVerificationDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                //UserProfileName = response.UserProfile.FirstName + " " + response.UserProfile.LastName,
                PoliceStationName = response.PoliceStationName,
                VerificationStatus = response.VerificationStatus,
                VerificationDate = response.VerificationDate,
                VerificationRemarks = response.VerificationRemarks,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
