using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class BodyMeasurementRepository : GenericRepository<BodyMeasurement>, IBodyMeasurementRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public BodyMeasurementRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<BodyMeasurementDetailDto?> GetByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.BodyMeasurements
                .AsNoTracking()
                .Where(body => body.UserProfileId == userProfile.Id && !body.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<BodyMeasurementDetailDto?> GetByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _context.BodyMeasurements
                .AsNoTracking()
                .Where(body => body.UserProfileId == userProfileId && !body.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<BodyMeasurementDetailDto?> GetBodyMeasurementByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.BodyMeasurements
                .AsNoTracking()
                .Where(body => body.Id == id && !body.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        private BodyMeasurementDetailDto MapToDto(Domain.Entity.Registration.BodyMeasurement body)
        {
            return new BodyMeasurementDetailDto
            {
                Id = body.Id,
                UserProfileId = body.UserProfileId,
                //UserProfileName = body.UserProfile.FirstName + " " + body.UserProfile.LastName,
                HeightCm = body.HeightCm,
                WeightKg = body.WeightKg,
                ChestCm = body.ChestCm,
                ShoulderCm = body.ShoulderCm,
                HairColour = body.HairColour,
                EyeColour = body.EyeColour,
                IsActive = body.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(body.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(body.DateModified),
                CreatedByName = body.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = body.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
