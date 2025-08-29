using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Menu;
using MC.Domain.Entity.Menu;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Menu
{
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<List<MenuItemDto>> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            return await _context.MenuItems.AsNoTracking()
                .Include(lt => lt.Menu)
                .Where(lt => !lt.IsDeleted)
                .Select(lt => new MenuItemDto
                {
                    Id = lt.Id,
                    MenuItemDisplayOrder = lt.MenuItemDisplayOrder,
                    Title = lt.Title,
                    Url = lt.Url,
                    IconUrl = lt.IconUrl,
                    MenuId = lt.MenuId,
                    MenuValue = lt.Menu != null ? lt.Menu.Title : string.Empty,
                })
                .ToListAsync(cancellationToken);
        }
        public async Task<MenuItemDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.MenuItems.AsNoTracking()
                .Include(lt => lt.Menu)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                 return null;
            
            var dto = new MenuItemDetailDto
            {
                Id = response.Id,
                MenuItemDisplayOrder = response.MenuItemDisplayOrder,
                Title = response.Title,
                Url = response.Url,
                IconUrl = response.IconUrl,
                MenuId = response.MenuId,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
            return dto;
        }

        public async Task<List<MenuItemDto>> GetMenuItemByMenuIdAsync(Guid menuId, CancellationToken cancellationToken)
        {
            return await _context.MenuItems.AsNoTracking()
                .Include(lt => lt.Menu)
                .Where(lt => lt.MenuId == menuId && !lt.IsDeleted && (lt.Menu == null || !lt.Menu.IsDeleted))
                .Select(lt => new MenuItemDto
                {
                    Id = lt.Id,
                    MenuItemDisplayOrder = lt.MenuItemDisplayOrder,
                    Title = lt.Title,
                    Url = lt.Url,
                    IconUrl = lt.IconUrl,
                    MenuId = lt.MenuId,
                    MenuValue = lt.Menu != null ? lt.Menu.Title : string.Empty,
                })
                .ToListAsync(cancellationToken);
        }
        public async Task<bool> IsUnique(string title, Guid menuId, CancellationToken cancellationToken)
        {
            return !await _context.MenuItems.AsNoTracking()
              .AnyAsync(q => q.Title == title && !q.IsDeleted && q.MenuId == menuId, cancellationToken);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.MenuItems.AsNoTracking()
                .AnyAsync(q => q.Title == value
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
    }
}
