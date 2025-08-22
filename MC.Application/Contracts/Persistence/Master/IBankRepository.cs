using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;

namespace MC.Application.Contracts.Persistence.Master
{
    public interface IBankRepository : IGenericRepository<Bank>
    {
        Task<BankDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<List<BankDto>> GetAllDetailsAsync(CancellationToken cancellationToken);
        Task<bool> IsUnique(string code, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
