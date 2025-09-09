using MC.Application.Contracts.Persistence;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Navigation;
using MC.Domain.Entity.Navigation;

namespace MC.Application.Contracts.Navigation
{
    public interface INavigationNodeRepository : IGenericRepository<NavigationNode>
    {
        Task<Guid> CreateWithRolesAsync(NavigationNode node, List<Guid> roleIds, CancellationToken cancellationToken);
        Task UpdateWithRolesAsync(NavigationNode node, List<Guid> roleIds, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(Guid nodeId, CancellationToken cancellationToken);
        Task<List<NavigationNodeDropdownDto>> GetParentNodesAsync(Guid? excludeId, CancellationToken cancellationToken);
        Task<NavigationNodeDto?> GetNavigationByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<PaginatedResponse<NavigationNodeDto>?> GetAllAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<List<NavigationNodeDto>> GetNavigationsForRolesAsync(IList<string> roles, CancellationToken cancellationToken);
        Task<List<NavigationNodeDto>> GetTreeAsync(CancellationToken cancellationToken);
        Task<NavigationNode?> GetWithChildrenAsync(Guid id, CancellationToken cancellationToken);
    }
}
