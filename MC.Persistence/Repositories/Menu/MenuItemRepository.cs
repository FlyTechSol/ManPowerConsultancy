using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Menu;
using MC.Domain.Entity.Menu;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace MC.Persistence.Repositories.Menu
{
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<List<MenuItemDto>> GetAllDetailsAsync()
        {
            return await _context.MenuItems
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
                .ToListAsync();
        }

        public async Task<MenuItemDetailDto?> GetDetailsAsync(Guid id)
        {
            var response = await _context.MenuItems
                .Include(lt => lt.Menu)
                .Include(lt => lt.CreatedByUser)
                .Include(lt => lt.ModifiedByUser)
                 .Where(lt => !lt.IsDeleted)
                .FirstOrDefaultAsync(lt => lt.Id == id);

            if (response == null)
            {
                return null;
            }

            var dto = new MenuItemDetailDto
            {
                Id = response.Id,
                MenuItemDisplayOrder = response.MenuItemDisplayOrder,
                Title = response.Title,
                Url = response.Url,
                IconUrl = response.IconUrl,
                MenuId = response.MenuId,
                DateCreated = response.DateCreated.HasValue
                    ? response.DateCreated.Value.ToString("dd-MM-yyyy HH:mm:ss")
                    : string.Empty,
                DateModified = response.DateModified.HasValue
                    ? response.DateModified.Value.ToString("dd-MM-yyyy HH:mm:ss")
                    : string.Empty,
                CreatedByName = response.CreatedByUser != null
                    ? $"{response.CreatedByUser.FirstName} {response.CreatedByUser.LastName}"
                    : string.Empty,
                ModifiedByName = response.ModifiedByUser != null
                    ? $"{response.ModifiedByUser.FirstName} {response.ModifiedByUser.LastName}"
                    : string.Empty
            };

            return dto;
        }

        public async Task<List<MenuItemDto>> GetMenuItemByMenuIdAsync(Guid menuId)
        {
            return await _context.MenuItems
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
                .ToListAsync();
        }
        public async Task<bool> IsUnique(string title, Guid menuId)
        {
            return !await _context.MenuItems
              .Where(q => q.Title == title && !q.IsDeleted && q.MenuId == menuId)  // Exclude deleted records
              .AnyAsync();
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string value)
        {
            // but exclude the current record by Id and records that are marked as deleted.
            return !await _context.MenuItems
                .Where(q => q.Title == value
                            && q.Id != id
                            && !q.IsDeleted)  // Exclude deleted records
                .AnyAsync();
        }
    }
}
