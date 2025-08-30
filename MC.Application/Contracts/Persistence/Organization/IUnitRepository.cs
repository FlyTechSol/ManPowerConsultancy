using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MC.Domain.Entity.Organization;

namespace MC.Application.Contracts.Persistence.Organization
{
    public interface IUnitRepository : IGenericRepository<ClientUnit>
    {
        Task<UnitDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken); 
        Task<PaginatedResponse<UnitDetailDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<PaginatedResponse<UnitDetailDto>> GetUnitByClientMasterIdAsync(QueryParams queryParams, Guid clientMasterId, CancellationToken cancellationToken);
        Task<bool> IsUnique(Guid clientMasterId, string unitName, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, Guid clientMasterId, string unitName, CancellationToken cancellationToken);
    }
}
