using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Menu;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Menu
{
    public class MenuRepository : GenericRepository<Domain.Entity.Menu.Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<List<MenuDto>> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            return await _context.Menus
                .AsNoTracking()
                .Where(lt => !lt.IsDeleted)
                .Select(lt => new MenuDto
                {
                    Id = lt.Id,
                    MenuDisplayOrder = lt.MenuDisplayOrder,
                    Title = lt.Title,
                    IsParent = lt.IsParent,
                    NavigationURL = lt.NavigationURL,
                    IconUrl = lt.IconUrl,
                    RoleId = lt.RoleId,
                    RoleName = lt.Role != null ? lt.Role.Name ?? string.Empty : string.Empty,
                })
                .ToListAsync(cancellationToken);
        }
        public async Task<MenuDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Menus
                .AsNoTracking()
                .Include(lt => lt.Role)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            var dto = new MenuDetailDto
            {
                Id = response.Id,
                MenuDisplayOrder = response.MenuDisplayOrder,
                Title = response.Title,
                IsParent = response.IsParent,
                NavigationURL = response.NavigationURL,
                IconUrl = response.IconUrl,
                RoleId = response.RoleId,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
            return dto;
        }
        public async Task<List<MenuDto>> GetAllMenuWithRoleName(CancellationToken cancellationToken)
        {
            var result = await _context.Menus.AsNoTracking()
                .Include(q => q.Role) // Include related ApplicationRole
                .Where(q => !q.IsDeleted)
                .Select(m => new MenuDto
                {
                    Id = m.Id,
                    MenuDisplayOrder = m.MenuDisplayOrder,
                    Title = m.Title,
                    IsParent = m.IsParent,
                    NavigationURL = m.NavigationURL,
                    IconUrl = m.IconUrl,
                    RoleId = m.RoleId,
                    RoleName = m.Role != null ? m.Role.Name ?? string.Empty : string.Empty,
                    MenuItems = m.MenuItems.Select(mi => new MenuItemDto
                    {
                        Id = mi.Id,
                        MenuItemDisplayOrder = mi.MenuItemDisplayOrder,
                        Title = mi.Title,
                        IconUrl = mi.IconUrl,
                        MenuId = mi.MenuId,
                        MenuValue = mi.Menu != null ? mi.Menu.Title : string.Empty
                    }).ToList()
                })
                .ToListAsync(cancellationToken);
            return result;
        }
        public async Task<List<MenuTitleDto>> GetAllMenuTitleAsync(CancellationToken cancellationToken)
        {
            return await _context.Menus.AsNoTracking()
                .Include(lt => lt.Role)
                .Where(q => q.IsDeleted)
                .Select(lt => new MenuTitleDto
                {
                    Id = lt.Id,
                    Value = lt.Title + " - Role " + (lt.Role != null ? lt.Role.Name : string.Empty)
                })
                .ToListAsync(cancellationToken);
        }
        public async Task<bool> IsUnique(string title, Guid roleId, CancellationToken cancellationToken)
        {
            return !await _context.Menus.AsNoTracking().AnyAsync(q => q.Title == title && !q.IsDeleted && q.RoleId == roleId, cancellationToken);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string value, Guid roleId, CancellationToken cancellationToken)
        {
            return !await _context.Menus
                .AsNoTracking()
                .AnyAsync(q => q.Title == value && !q.IsDeleted && q.RoleId == roleId
                            && q.Id != id, cancellationToken);
        }
    }
}
