using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
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

        public async Task<UserGeneralDetailDto?> GetUserGeneralByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var result = await _context.UserGeneralDetails
                .AsNoTracking()
                .Include(a => a.UserProfile)
                .Include(a => a.Religion)
                .Include(a => a.Nationality)
                .Include(a => a.CasteCategory)
                .Include(a => a.HighestEducation)
                .Where(response => response.UserProfileId == userProfile.Id && !response.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (result == null)
                return null;

            return MapToDto(result);
        }
        public async Task<UserGeneralDetailDto?> GetUserGeneralByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var result = await _context.UserGeneralDetails
                 .AsNoTracking()
                 .Include(a => a.UserProfile)
                 .Include(a => a.Religion)
                 .Include(a => a.Nationality)
                 .Include(a => a.CasteCategory)
                 .Include(a => a.HighestEducation)
                 .Where(response => response.UserProfileId == userProfileId && !response.IsDeleted)
                 .FirstOrDefaultAsync(cancellationToken);

            if (result == null)
                return null;

            return MapToDto(result);
        }

        public async Task<UserGeneralDetailDto?> GetUserGeneralByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _context.UserGeneralDetails
                 .AsNoTracking()
                 .Include(a => a.UserProfile)
                 .Include(a => a.Religion)
                 .Include(a => a.Nationality)
                 .Include(a => a.CasteCategory)
                 .Include(a => a.HighestEducation)
                 .Where(response => response.Id == id && !response.IsDeleted)
                 .FirstOrDefaultAsync(cancellationToken);

            if (result == null)
                return null;

            return MapToDto(result);
        }
        private UserGeneralDetailDto MapToDto(Domain.Entity.Registration.UserGeneralDetail response)
        {
            return new UserGeneralDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                UserProfileName = response.UserProfile.FirstName + " " + response.UserProfile.LastName,
                FatherName = response.FatherName,
                MotherName = response.MotherName,
                SpouseName = response.SpouseName,
                ReligionId = response.ReligionId,
                ReligionName = response.Religion != null ? response.Religion.Name : string.Empty,
                CountryId = response.CountryId,
                Nationality = response.Nationality != null ? response.Nationality.Name : string.Empty,
                CasteCategoryId = response.CasteCategoryId,
                CasteCategoryName = response.CasteCategory != null ? response.CasteCategory.Name : string.Empty,
                HighestEducationId = response.HighestEducationId,
                HighestEducationName = response.HighestEducation != null ? response.HighestEducation.Name : string.Empty,
                DifferentlyAbled = response.DifferentlyAbled,
                MaritalStatus = response.MaritalStatus,
                IdentityMarks = response.IdentityMarks,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
