using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class UserGeneralDetailRepository : GenericRepository<UserGeneralDetail>, IUserGeneralDetailRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserGeneralDetailRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<UserGeneralDetailDto?> GetUserGeneralByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var address = await _context.UserGeneralDetails
                .AsNoTracking()
                .Include(a => a.UserProfile)
                .Include(a => a.Religion)
                .Include(a => a.Nationality)
                .Include(a => a.CasteCategory)
                .Include(a => a.HighestEducation)
                .Include(a => a.CreatedByUser!)
                    .ThenInclude(u => u.UserProfile)
                .Include(a => a.ModifiedByUser!)
                    .ThenInclude(u => u.UserProfile)
                .Where(addr => addr.UserProfileId == userProfile.Id && addr.IsActive)
                .Select(addr => new UserGeneralDetailDto
                {
                    Id = addr.Id,
                    UserProfileId = addr.UserProfileId,
                    UserProfileName = addr.UserProfile.FirstName + " " + addr.UserProfile.LastName,
                    FatherName = addr.FatherName,
                    MotherName = addr.MotherName,
                    SpouseName = addr.SpouseName,
                    ReligionId = addr.ReligionId,
                    ReligionName = addr.Religion != null ? addr.Religion.Name : string.Empty,
                    CountryId = addr.CountryId,
                    Nationality = addr.Nationality != null ? addr.Nationality.Name : string.Empty,
                    CasteCategoryId = addr.CasteCategoryId,
                    CasteCategoryName = addr.CasteCategory != null ? addr.CasteCategory.Name : string.Empty,
                    HighestEducationId = addr.HighestEducationId,
                    HighestEducationName = addr.HighestEducation != null ? addr.HighestEducation.Name : string.Empty,
                    DifferentlyAbled = addr.DifferentlyAbled,
                    MaritalStatus = addr.MaritalStatus,
                    IdentityMarks = addr.IdentityMarks,
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
