using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MC.Domain.Entity.Menu;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using static MC.Persistence.Helper.Defaults;

namespace MC.Persistence.Repositories.Menu
{
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<PaginatedResponse<MenuItemDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.MenuItems
                .AsNoTracking()
                .Include(mi => mi.Menu)
                .Where(mi => !mi.IsDeleted);

            // Optional search
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(mi =>
                    mi.Title.ToLower().Contains(search) ||
                    (mi.Menu != null && mi.Menu.Title.ToLower().Contains(search)) ||
                    (mi.Role != null && !string.IsNullOrWhiteSpace(mi.Role.Name) && mi.Role.Name.ToLower().Contains(search))
                );
            }
            var totalCount = await query.CountAsync(cancellationToken);

            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                var direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "ascending";
                query = query.OrderBy($"{queryParams.Column} {direction}");
            }
            else
            {
                query = query.OrderBy(mi => mi.MenuItemDisplayOrder); // Default sort
            }
            var items = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .Select(mi => new MenuItemDto
                {
                    Id = mi.Id,
                    MenuItemDisplayOrder = mi.MenuItemDisplayOrder,
                    Title = mi.Title,
                    Url = mi.Url,
                    IconUrl = mi.IconUrl,
                    MenuId = mi.MenuId,
                    MenuValue = mi.Menu != null ? mi.Menu.Title : string.Empty,
                    RoleId = mi.RoleId,
                    RoleName = mi.Role != null ? mi.Role.Name ?? string.Empty : string.Empty,
                })
                .ToListAsync(cancellationToken);

            return new PaginatedResponse<MenuItemDto>
            {
                Data = items,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        public async Task<MenuItemDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.MenuItems.AsNoTracking()
                .Include(lt => lt.Menu)
                .Include(lt => lt.Role)
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
                MenuValue = response.Menu != null ? response.Menu.Title ?? string.Empty : string.Empty,
                RoleId = response.RoleId,
                RoleName = response.Role != null ? response.Role.Name ?? string.Empty : string.Empty,   
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
            return dto;
        }

        public async Task<PaginatedResponse<MenuItemDto>> GetMenuItemByMenuIdAsync(QueryParams queryParams, Guid menuId, CancellationToken cancellationToken)
        {
            var query = _context.MenuItems.AsNoTracking()
                .Include(lt => lt.Menu)
                .Include(lt => lt.Role)
                .Where(lt => lt.MenuId == menuId && !lt.IsDeleted && (lt.Menu == null || !lt.Menu.IsDeleted));

            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(mi =>
                    mi.Title.ToLower().Contains(search) ||
                    (mi.Menu != null && mi.Menu.Title.ToLower().Contains(search)) ||
                    (mi.Role != null && !string.IsNullOrWhiteSpace(mi.Role.Name) && mi.Role.Name.ToLower().Contains(search))
                );
            }
            var totalCount = await query.CountAsync(cancellationToken);

            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                var direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "ascending";
                query = query.OrderBy($"{queryParams.Column} {direction}");
            }
            else
            {
                query = query.OrderBy(mi => mi.MenuItemDisplayOrder); // Default sort
            }

            var items = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .Select(mi => new MenuItemDto
                {
                    Id = mi.Id,
                    MenuItemDisplayOrder = mi.MenuItemDisplayOrder,
                    Title = mi.Title,
                    Url = mi.Url,
                    IconUrl = mi.IconUrl,
                    MenuId = mi.MenuId,
                    MenuValue = mi.Menu != null ? mi.Menu.Title : string.Empty,
                    RoleId = mi.RoleId,
                    RoleName = mi.Role != null ? mi.Role.Name ?? string.Empty : string.Empty,
                })
                .ToListAsync(cancellationToken);

            return new PaginatedResponse<MenuItemDto>
            {
                Data = items,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        public async Task<bool> IsUnique(string title, Guid menuId, Guid roleId,  CancellationToken cancellationToken)
        {
            return !await _context.MenuItems.AsNoTracking()
              .AnyAsync(q => q.Title == title && !q.IsDeleted && q.MenuId == menuId && q.RoleId == roleId, cancellationToken);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string title, Guid menuId, Guid roleId, CancellationToken cancellationToken)
        {
            return !await _context.MenuItems.AsNoTracking()
                .AnyAsync(q => q.Title == title
                            && q.MenuId == menuId 
                            && q.RoleId == roleId
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }

        public async Task<PaginatedResponse<MenuItemTitleDto>> GetAllMenuTitleAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.MenuItems
                .AsNoTracking()
                .Include(lt => lt.Role)
                .Where(q => q.IsDeleted);

            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(mi =>
                    (mi.Title != null && mi.Title.ToLower().Contains(search))
                );
            }
            var totalCount = await query.CountAsync(cancellationToken);

            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                var direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "ascending";
                query = query.OrderBy($"{queryParams.Column} {direction}");
            }
            else
            {
                query = query.OrderBy(mi => mi.MenuItemDisplayOrder); // Default sort
            }
            var items = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .Select(mi => new MenuItemTitleDto
                {
                    Id = mi.Id,
                    Value = mi.Title + " - Role " + (mi.Role != null ? mi.Role.Name : string.Empty)
                })
                .ToListAsync(cancellationToken);

            return new PaginatedResponse<MenuItemTitleDto>
            {
                Data = items,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
    }
}
