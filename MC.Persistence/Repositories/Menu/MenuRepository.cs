using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Menu
{
    public class MenuRepository : GenericRepository<Domain.Entity.Menu.Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<PaginatedResponse<MenuDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.Menus
                .AsNoTracking()
                .Where(mi => !mi.IsDeleted);

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
                query = query.OrderBy(mi => mi.MenuDisplayOrder); // Default sort
            }
            var items = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .Select(mi => new MenuDto
                {
                    Id = mi.Id,
                    MenuDisplayOrder = mi.MenuDisplayOrder,
                    Title = mi.Title,
                    //IsParent = mi.IsParent,
                    //NavigationURL = mi.NavigationURL,
                    IconUrl = mi.IconUrl,
                    //RoleId = mi.RoleId,
                    //RoleName = mi.Role != null ? mi.Role.Name ?? string.Empty : string.Empty,
                })
                .ToListAsync(cancellationToken);

            return new PaginatedResponse<MenuDto>
            {
                Data = items,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        public async Task<MenuDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Menus
                .AsNoTracking()
                //.Include(lt => lt.Role)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            var dto = new MenuDetailDto
            {
                Id = response.Id,
                MenuDisplayOrder = response.MenuDisplayOrder,
                Title = response.Title,
                //IsParent = response.IsParent,
                //NavigationURL = response.NavigationURL,
                IconUrl = response.IconUrl,
                //RoleId = response.RoleId,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
            return dto;
        }
        public async Task<PaginatedResponse<MenuDto>> GetAllMenuWithRoleName(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.Menus
                .AsNoTracking()
                .Include(m => m.MenuItems)
                .Where(m => !m.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(m =>
                    m.Title.ToLower().Contains(search) 
                );
            }

            // Count before pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                var direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "ascending";
                query = query.OrderBy($"{queryParams.Column} {direction}");
            }
            else
            {
                query = query.OrderBy(m => m.MenuDisplayOrder);
            }

            // Fetch data first into anonymous type
            var rawItems = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .Select(m => new
                {
                    m.Id,
                    m.MenuDisplayOrder,
                    m.Title,
                    //m.IsParent,
                    //m.NavigationURL,
                    m.IconUrl,
                    //m.RoleId,
                    //RoleName = m.Role != null ? m.Role.Name ?? string.Empty : string.Empty,
                    MenuItems = m.MenuItems
                        .Where(mi => !mi.IsDeleted)
                        .Select(mi => new
                        {
                            mi.Id,
                            mi.MenuItemDisplayOrder,
                            mi.Title,
                            mi.IconUrl,
                            mi.MenuId,
                            MenuValue = mi.Menu != null ? mi.Menu.Title : string.Empty
                        }).ToList()
                })
                .ToListAsync(cancellationToken);

            // Convert to DTOs in memory
            var items = rawItems.Select(m => new MenuDto
            {
                Id = m.Id,
                MenuDisplayOrder = m.MenuDisplayOrder,
                Title = m.Title,
                //IsParent = m.IsParent,
                //NavigationURL = m.NavigationURL,
                IconUrl = m.IconUrl,
                //RoleId = m.RoleId,
                //RoleName = m.RoleName,
                MenuItems = m.MenuItems.Select(mi => new MenuItemDto
                {
                    Id = mi.Id,
                    MenuItemDisplayOrder = mi.MenuItemDisplayOrder,
                    Title = mi.Title,
                    IconUrl = mi.IconUrl,
                    MenuId = mi.MenuId,
                    MenuValue = mi.MenuValue
                }).ToList()
            }).ToList();

            return new PaginatedResponse<MenuDto>
            {
                Data = items,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        public async Task<bool> IsUnique(string title, CancellationToken cancellationToken)
        {
            return !await _context.Menus.AsNoTracking().AnyAsync(q => q.Title == title && !q.IsDeleted, cancellationToken);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.Menus
                .AsNoTracking()
                .AnyAsync(q => q.Title == value && !q.IsDeleted 
                            && q.Id != id, cancellationToken);
        }
    }
}
