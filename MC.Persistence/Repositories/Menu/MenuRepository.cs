using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Menu;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace MC.Persistence.Repositories.Menu
{
    public class MenuRepository : GenericRepository<Domain.Entity.Menu.Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<List<MenuDto>> GetAllDetailsAsync()
        {
            return await _context.Menus
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
                    RoleName = lt.Role != null ? lt.Role.Name : string.Empty,
                })
                .ToListAsync();
        }

        public async Task<MenuDetailDto?> GetDetailsAsync(Guid id)
        {
            var response = await _context.Menus
                .Include(lt => lt.Role)
                .Include(lt => lt.CreatedByUser)
                .Include(lt => lt.ModifiedByUser)
                .Where(lt => !lt.IsDeleted)
                .FirstOrDefaultAsync(lt => lt.Id == id);

            if (response == null)
            {
                return null;
            }

            var dto = new MenuDetailDto
            {
                Id = response.Id,
                MenuDisplayOrder = response.MenuDisplayOrder,
                Title = response.Title,
                IsParent = response.IsParent,
                NavigationURL = response.NavigationURL,
                IconUrl = response.IconUrl,
                RoleId = response.RoleId,
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

        public async Task<List<MenuDto>> GetAllMenuWithRoleName()
        {
            var result = await _context.Menus
                .Include(m => m.Role) // Include related ApplicationRole
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
                    RoleName = m.Role.Name, // Map RoleName
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
                .ToListAsync();

            return result;
        }

        public async Task<List<MenuTitleDto>> GetAllMenuTitleAsync()
        {
            return await _context.Menus
                .Include(lt => lt.Role)
                .Where(q => q.IsDeleted)
                .Select(lt => new MenuTitleDto
                {
                    Id = lt.Id,
                    Value = lt.Title + " - Role " + (lt.Role != null ? lt.Role.Name : string.Empty) // Corrected conditional operator
                })
                .ToListAsync();
        }
        public async Task<bool> IsUnique(string title, Guid roleId)
        {
            return !await _context.Menus.AnyAsync(q => q.Title == title && !q.IsDeleted && q.RoleId == roleId);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string value, Guid roleId)
        {
            // but exclude the current record by Id and records that are marked as deleted.
            return !await _context.Menus
                .Where(q => q.Title == value && !q.IsDeleted && q.RoleId == roleId
                            && q.Id != id)  // Exclude deleted records
                .AnyAsync();
        }
    }
}
