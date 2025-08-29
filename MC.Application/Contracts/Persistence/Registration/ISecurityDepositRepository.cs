using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface ISecurityDepositRepository : IGenericRepository<SecurityDeposit>
    {
        Task<SecurityDepositDetailDto?> GetSecurityDepositByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<SecurityDepositDetailDto?> GetSecurityDepositByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<SecurityDepositDetailDto?> GetSecurityDepositByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
