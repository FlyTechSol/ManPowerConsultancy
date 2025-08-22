using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<UserProfileShortDto?> GetUserProfileByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            return await _context.UserProfiles
                .AsNoTracking()
                .Where(up => up.RegistrationId == registrationId && !up.IsDeleted)
                .Select(up => new UserProfileShortDto
                {
                    Id = up.Id,
                    RegistrationId = up.RegistrationId,
                    FirstName = up.FirstName,
                    LastName = up.LastName,
                    Email = up.Email,
                    MobileNumber = up.MobileNumber,
                    RoleName="",
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
