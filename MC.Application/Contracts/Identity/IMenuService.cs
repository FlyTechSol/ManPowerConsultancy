using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MC.Application.ModelDto.Navigation;

namespace MC.Application.Contracts.Identity
{
    public interface IMenuService
    {
        //Task<List<NavigationNodeDto>> GetNavigationsForRolesAsync(IList<string> roles, CancellationToken cancellationToken);
        Task<PaginatedResponse<MenuDto>> GetNavigationsForRolesAsync(QueryParams queryParams, IList<string> roles, CancellationToken cancellationToken);
        public Task<List<MenuDto>> GetMenusForRolesAsync(IList<string> roles, CancellationToken cancellationToken);
       
    }
}
