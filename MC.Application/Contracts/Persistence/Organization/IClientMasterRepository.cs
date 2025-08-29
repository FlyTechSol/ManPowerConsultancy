using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Organization;
using MC.Domain.Entity.Organization;

namespace MC.Application.Contracts.Persistence.Organization
{
    public interface IClientMasterRepository : IGenericRepository<ClientMaster>
    {
        Task<ClientMasterDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<List<ClientMasterDetailDto>> GetAllDetailsAsync(CancellationToken cancellationToken);
        Task<List<ClientMasterDetailDto>> GetClientMasterByCompanyIdAsync(Guid companyId, CancellationToken cancellationToken);
        Task<bool> IsUnique(Guid companyId, string clientName, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, Guid companyId, string clientName, CancellationToken cancellationToken);
    }
}

