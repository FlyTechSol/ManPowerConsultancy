using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;

namespace MC.Application.Contracts.Persistence.Master
{
    public interface IReligionRepository : IGenericRepository<Religion>
    {
        Task<ReligionDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<PaginatedResponse<ReligionDetailDto>?> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<bool> IsUnique(string code, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
