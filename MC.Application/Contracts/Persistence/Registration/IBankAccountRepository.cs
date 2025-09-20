using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using Microsoft.AspNetCore.Http;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IBankAccountRepository : IGenericRepository<BankAccount>
    {
        Task<PaginatedResponse<BankAccountDetailDto>?> GetAllDetailsAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<bool> IsUnique(string ifscCode, string accountNo, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string ifscCode, string accountNo, CancellationToken cancellationToken);
        //Task<BankAccountDetailDto?> GetActiveRecordByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        //Task<List<BankAccountDetailDto>?> GetInactiveRecordByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        //Task<BankAccountDetailDto?> GetActiveRecordByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        //Task<List<BankAccountDetailDto>?> GetInactiveRecordByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<Guid> CreateBankAccountAsync(BankAccount request, IFormFile? passbookUrl, CancellationToken cancellationToken);
        Task<Guid> UpdateBankAccountAsync(BankAccount request, IFormFile? passbookUrl, CancellationToken cancellationToken);
        Task<BankAccountDetailDto?> GetDetailByIdAsync(Guid Id, CancellationToken cancellationToken);
        Task<List<BankAccount>> GetAllByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task UpdateRangeAsync(IEnumerable<BankAccount> bankaccounts, CancellationToken cancellationToken);
    }
}
