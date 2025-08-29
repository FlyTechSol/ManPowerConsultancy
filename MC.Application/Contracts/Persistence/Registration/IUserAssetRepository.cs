using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IUserAssetRepository : IGenericRepository<UserAsset>
    {
        Task<List<UserAssetDetailDto>?> GetAllUserAssetByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<List<UserAssetDetailDto>?> GetAllUserAssetByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<UserAssetDetailDto?> GetUserAssetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
