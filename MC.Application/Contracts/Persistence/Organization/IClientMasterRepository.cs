using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MC.Domain.Entity.Organization;

namespace MC.Application.Contracts.Persistence.Organization
{
    public interface IClientMasterRepository : IGenericRepository<ClientMaster>
    {
        Task<ClientMasterDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<PaginatedResponse<ClientMasterDetailDto>?> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<PaginatedResponse<ClientMasterDetailDto>?> GetClientMasterByCompanyIdAsync(QueryParams queryParams, Guid companyId, CancellationToken cancellationToken);
        Task<bool> IsUnique(Guid companyId, string clientName, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, Guid companyId, string clientName, CancellationToken cancellationToken);
    }
}

