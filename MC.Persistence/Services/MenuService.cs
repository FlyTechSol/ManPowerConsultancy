using MC.Application.Contracts.Identity;
using MC.Application.ModelDto.Menu;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace MC.Persistence.Services
{
    internal class MenuService : IMenuService
    {
        private readonly ApplicationDatabaseContext _context;
        public MenuService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<MenuDto>> GetMenusForRolesAsync(IList<string> roles)
        {
            var menus = await _context.Menus
                .Include(m => m.MenuItems)
                .Where(m => roles.Contains(m.Role.Name) && !m.IsDeleted)  // Filtering at DB level for roles and deleted menus
                .Select(m => new MenuDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    MenuDisplayOrder = m.MenuDisplayOrder,
                    IsParent = m.IsParent,
                    NavigationURL = m.NavigationURL,
                    IconUrl = m.IconUrl,
                    RoleId = m.RoleId,
                    RoleName = m.Role.Name ?? string.Empty,
                    MenuItems = m.MenuItems
                        .Where(mi => !mi.IsDeleted)  // Filter non-deleted MenuItems
                        .Select(mi => new MenuItemDto
                        {
                            Id = mi.Id,
                            Title = mi.Title,
                            MenuItemDisplayOrder = mi.MenuItemDisplayOrder,
                            Url = mi.Url,
                            IconUrl = mi.IconUrl,
                            MenuId = mi.MenuId,
                        })
                        .ToList()  // Return empty list if no non-deleted MenuItems
                })
                .ToListAsync();
            return menus;
        }
    }
}
