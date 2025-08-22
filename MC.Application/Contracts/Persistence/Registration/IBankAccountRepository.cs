using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IBankAccountRepository : IGenericRepository<BankAccount>
    {
        //Task<List<BankAccountDto>> GetAllDetailsAsync(CancellationToken cancellationToken);
        //Task<BankAccountDto?> GetDetailsAsync(Guid userId, CancellationToken cancellationToken);
        Task<bool> IsUnique(string ifscCode, string accountNo, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string ifscCode, string accountNo, CancellationToken cancellationToken);
        Task<BankAccountDetailDto?> GetActiveRecordByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<List<BankAccountDetailDto>?> GetInactiveRecordByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<BankAccountDetailDto?> GetDetailByIdAsync(Guid Id, CancellationToken cancellationToken);
        Task<List<BankAccount>> GetAllByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task UpdateRangeAsync(IEnumerable<BankAccount> bankaccounts, CancellationToken cancellationToken);
    }
}
