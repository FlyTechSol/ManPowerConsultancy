using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IUserGeneralDetailRepository : IGenericRepository<UserGeneralDetail>
    {
        Task<UserGeneralDetailDto?> GetUserGeneralByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<UserGeneralDetailDto?> GetUserGeneralByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<UserGeneralDetailDto?> GetUserGeneralByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
