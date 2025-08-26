using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IUserAssetRepository : IGenericRepository<UserAsset>
    {
        Task<UserAssetDetailDto?> GetAllUserAssetByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken);
        Task<UserAssetDetailDto?> GetUserAssetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
