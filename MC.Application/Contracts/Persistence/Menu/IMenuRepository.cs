using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;

namespace MC.Application.Contracts.Persistence.Menu
{
    public interface IMenuRepository : IGenericRepository<Domain.Entity.Menu.Menu>
    {
        Task<PaginatedResponse<MenuDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<MenuDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<PaginatedResponse<MenuDto>> GetAllMenuWithRoleName(QueryParams queryParams, CancellationToken cancellationToken);
        //Task<PaginatedResponse<MenuItemTitleDto>> GetAllMenuTitleAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<bool> IsUnique(string title, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
