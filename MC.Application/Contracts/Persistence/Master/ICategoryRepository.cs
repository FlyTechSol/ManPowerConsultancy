using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;

namespace MC.Application.Contracts.Persistence.Master
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<CategoryDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<List<CategoryDetailDto>> GetAllDetailsAsync(CancellationToken cancellationToken);
        Task<bool> IsUnique(string code, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
