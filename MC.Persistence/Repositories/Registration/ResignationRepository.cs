using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class ResignationRepository : GenericRepository<Resignation>, IResignationRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public ResignationRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<ResignationDetailDto?> GetByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.Resignations
                .AsNoTracking()
                .Where(res => res.UserProfileId == userProfile.Id && !res.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<ResignationDetailDto?> GetByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _context.Resignations
                 .AsNoTracking()
                 .Where(res => res.UserProfileId == userProfileId && !res.IsDeleted)
                 .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<ResignationDetailDto?> GetResignationByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Resignations
                .AsNoTracking()
                .Where(res => res.Id == id && !res.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        private ResignationDetailDto MapToDto(Domain.Entity.Registration.Resignation response)
        {
            return new ResignationDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                //UserProfileName = response.UserProfile.FirstName + " " + response.UserProfile.LastName,
                ResignationDate = response.ResignationDate,
                Reason = response.Reason,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}