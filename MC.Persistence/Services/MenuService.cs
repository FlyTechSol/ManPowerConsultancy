using MC.Application.Contracts.Identity;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MC.Application.ModelDto.Navigation;
using MC.Domain.Entity.Navigation;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Services
{
    internal class MenuService : IMenuService
    {
        private readonly ApplicationDatabaseContext _context;
        public MenuService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
       

        public async Task<List<MenuDto>> GetMenusForRolesAsync(IList<string> roles, CancellationToken cancellationToken)
        {
            var menus = await _context.Menus
                .AsNoTracking()
                .Include(m => m.MenuItems.Where(mi => !mi.IsDeleted && mi.Role != null && roles.Contains(mi.Role.Name!)))
                    .ThenInclude(mi => mi.Role)
                .Where(m => !m.IsDeleted && m.MenuItems.Any(mi => mi.Role != null && roles.Contains(mi.Role.Name!)))
                .OrderBy(m => m.MenuDisplayOrder)
                .ToListAsync(cancellationToken);

            var result = menus.Select(menu => new MenuDto
            {
                Id = menu.Id,
                Title = menu.Title,
                MenuDisplayOrder = menu.MenuDisplayOrder,
                //IsParent = menu.IsParent,
                //NavigationURL = menu.NavigationURL,
                IconUrl = menu.IconUrl,
                MenuItems = menu.MenuItems
                    .OrderBy(mi => mi.MenuItemDisplayOrder)
                    .Select(mi => new MenuItemDto
                    {
                        Id = mi.Id,
                        Title = mi.Title,
                        MenuItemDisplayOrder = mi.MenuItemDisplayOrder,
                        Url = mi.Url,
                        IconUrl = mi.IconUrl,
                        MenuId = mi.MenuId,
                        RoleId = mi.RoleId,
                        RoleName = mi.Role?.Name ?? string.Empty
                    }).ToList(),
                DateCreated = Helper.DateHelper.FormatDate(menu.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(menu.DateModified),
                CreatedByName = menu.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = menu.ModifiedByUserName ?? Defaults.Users.Unknown,
            }).ToList();

            return result;
        }

        public async Task<PaginatedResponse<MenuDto>> GetNavigationsForRolesAsync(QueryParams queryParams, IList<string> roles, CancellationToken cancellationToken)
        {
            // Filter menus that have at least one menu item with a matching role
            var query = _context.Menus
                .AsNoTracking()
                .Include(m => m.MenuItems)
                    .ThenInclude(mi => mi.Role) // Assuming MenuItem has Role navigation
                .Where(m => !m.IsDeleted && m.MenuItems.Any(mi =>
                    !mi.IsDeleted &&
                    mi.Role != null &&
                    roles.Contains(mi.Role.Name!)));

            // Optional search
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(m => m.Title.ToLower().Contains(search));
            }

            // Total count
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                var sortDirection = queryParams.Dir?.ToLower() == "desc" ? "descending" : "ascending";
                query = query.OrderBy($"{queryParams.Column} {sortDirection}");
            }
            else
            {
                query = query.OrderBy(m => m.MenuDisplayOrder);
            }

            // Pagination & Projection
            var rawMenus = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .Select(m => new
                {
                    m.Id,
                    m.Title,
                    m.MenuDisplayOrder,
                    //m.IsParent,
                    //m.NavigationURL,
                    m.IconUrl,
                    MenuItems = m.MenuItems
                        .Where(mi => !mi.IsDeleted && mi.Role != null && roles.Contains(mi.Role.Name!))
                        .Select(mi => new MenuItemDto
                        {
                            Id = mi.Id,
                            Title = mi.Title,
                            MenuItemDisplayOrder = mi.MenuItemDisplayOrder,
                            Url = mi.Url,
                            IconUrl = mi.IconUrl,
                            MenuId = mi.MenuId,
                            RoleId = mi.RoleId,
                            RoleName = mi.Role != null ? mi.Role.Name! : string.Empty
                        }),
                    m.DateCreated,
                    m.DateModified,
                    m.CreatedByUserName,
                    m.ModifiedByUserName
                })
                .ToListAsync(cancellationToken);

            // Map to DTOs
            var menus = rawMenus.Select(m => new MenuDto
            {
                Id = m.Id,
                Title = m.Title,
                MenuDisplayOrder = m.MenuDisplayOrder,
                //IsParent = m.IsParent,
                //NavigationURL = m.NavigationURL,
                IconUrl = m.IconUrl,
                MenuItems = m.MenuItems.ToList(),
                DateCreated = Helper.DateHelper.FormatDate(m.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(m.DateModified),
                CreatedByName = m.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = m.ModifiedByUserName ?? Defaults.Users.Unknown,
            }).ToList();

            return new PaginatedResponse<MenuDto>
            {
                Data = menus,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        
    }
}
