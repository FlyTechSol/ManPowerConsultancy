using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;

namespace MC.Application.Contracts.Identity
{
    public interface IMenuService
    {
        Task<PaginatedResponse<MenuDto>> GetMenusForRolesAsync(QueryParams queryParams, IList<string> roles, CancellationToken cancellationToken);
        public Task<List<MenuDto>> GetMenusForRolesAsync(IList<string> roles, CancellationToken cancellationToken);
    }
}
