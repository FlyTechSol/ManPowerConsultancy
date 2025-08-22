using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        Task<UserProfileShortDto?> GetUserProfileByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
    }
}
