using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MC.Domain.Entity.Menu;

namespace MC.Application.Contracts.Persistence.Menu
{
    public interface IMenuItemRepository : IGenericRepository<MenuItem> 
    {
        Task<PaginatedResponse<MenuItemDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<MenuItemDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<PaginatedResponse<MenuItemDto>> GetMenuItemByMenuIdAsync(QueryParams queryParams, Guid menuId, CancellationToken cancellationToken);
        Task<bool> IsUnique(string title, Guid menuId, Guid roleId, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string title, Guid menuId, Guid roleId, CancellationToken cancellationToken);
        Task<PaginatedResponse<MenuItemTitleDto>> GetAllMenuTitleAsync(QueryParams queryParams, CancellationToken cancellationToken);
    }
}
