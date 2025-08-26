using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
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

        public async Task<PoliceVerificationDetailDto?> GetPolicleVerificationByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var address = await _context.PoliceVerifications
                .AsNoTracking()
                .Include(a => a.UserProfile)
                .Include(a => a.CreatedByUser!)
                    .ThenInclude(u => u.UserProfile)
                .Include(a => a.ModifiedByUser!)
                    .ThenInclude(u => u.UserProfile)
                .Where(addr => addr.UserProfileId == userProfile.Id && addr.IsActive)
                .Select(addr => new PoliceVerificationDetailDto
                {
                    Id = addr.Id,
                    UserProfileId = addr.UserProfileId,
                    UserProfileName = addr.UserProfile.FirstName + " " + addr.UserProfile.LastName,
                    PoliceStationName = addr.PoliceStationName,
                    VerificationStatus = addr.VerificationStatus,
                    VerificationDate = addr.VerificationDate,
                    VerificationRemarks = addr.VerificationRemarks,
                    IsActive = addr.IsActive,
                    DateCreated = Helper.DateHelper.FormatDate(addr.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(addr.DateModified),
                    CreatedByName = Helper.UserHelper.GetFormattedName(addr.CreatedByUser),
                    ModifiedByName = Helper.UserHelper.GetFormattedName(addr.ModifiedByUser),

                })
                .FirstOrDefaultAsync(cancellationToken);

            return address;
        }
    }
}
