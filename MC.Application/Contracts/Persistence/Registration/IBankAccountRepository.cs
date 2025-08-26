using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IBankAccountRepository : IGenericRepository<BankAccount>
    {
        Task<bool> IsUnique(string ifscCode, string accountNo, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string ifscCode, string accountNo, CancellationToken cancellationToken);
        Task<BankAccountDetailDto?> GetActiveRecordByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken);
        Task<List<BankAccountDetailDto>?> GetInactiveRecordByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken);
        Task<BankAccountDetailDto?> GetDetailByIdAsync(Guid Id, CancellationToken cancellationToken);
        Task<List<BankAccount>> GetAllByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task UpdateRangeAsync(IEnumerable<BankAccount> bankaccounts, CancellationToken cancellationToken);
    }
}
