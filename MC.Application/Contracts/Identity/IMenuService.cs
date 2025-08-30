using MC.Application.ModelDto.Menu;

namespace MC.Application.Contracts.Identity
{
    public interface IMenuService
    {
        Task<List<MenuDto>> GetMenusForRolesAsync(IList<string> roles);
    }
}
