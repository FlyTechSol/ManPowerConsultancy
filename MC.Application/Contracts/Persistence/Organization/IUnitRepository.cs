using MC.Application.ModelDto.Organization;
using MC.Domain.Entity.Organization;

namespace MC.Application.Contracts.Persistence.Organization
{
    public interface IUnitRepository : IGenericRepository<ClientUnit>
    {
        Task<UnitDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken); 
        Task<List<UnitDetailDto>> GetAllDetailsAsync(CancellationToken cancellationToken);
        Task<List<UnitDetailDto>> GetUnitByClientMasterIdAsync(Guid clientMasterId, CancellationToken cancellationToken);
        Task<bool> IsUnique(Guid clientMasterId, string unitName, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, Guid clientMasterId, string unitName, CancellationToken cancellationToken);
    }
}
