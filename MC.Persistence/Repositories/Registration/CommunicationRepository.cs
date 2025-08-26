using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class CommunicationRepository : GenericRepository<Communication>, ICommunicationRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public CommunicationRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }
        
        public async Task<CommunicationDetailDto?> GetByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var address = await _context.Communications
                .AsNoTracking()
                .Include(a => a.UserProfile)
                .Include(a => a.CreatedByUser!)
                    .ThenInclude(u => u.UserProfile)
                .Include(a => a.ModifiedByUser!)
                    .ThenInclude(u => u.UserProfile)
                .Where(addr => addr.UserProfileId == userProfile.Id && addr.IsActive)
                .Select(addr => new CommunicationDetailDto
                {
                    Id = addr.Id,
                    UserProfileId = addr.UserProfileId,
                    UserProfileName = addr.UserProfile.FirstName + " " + addr.UserProfile.LastName,
                    PersonalMobileNumber = addr.PersonalMobileNumber,
                    OfficialMobileNumber = addr.OfficialMobileNumber,
                    EmergencyContactNumber = addr.EmergencyContactNumber,
                    LandlineNumber1 = addr.LandlineNumber1,
                    LandlineNumber2 = addr.LandlineNumber2,
                    PersonalEmail = addr.PersonalEmail,
                    OfficialEmail = addr.OfficialEmail,
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
