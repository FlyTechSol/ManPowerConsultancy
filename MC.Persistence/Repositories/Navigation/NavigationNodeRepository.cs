using MC.Application.Contracts.Navigation;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Navigation;
using MC.Domain.Entity.Navigation;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Navigation
{
    public class NavigationNodeRepository : GenericRepository<NavigationNode>, INavigationNodeRepository
    {
        public NavigationNodeRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<NavigationNode?> GetWithChildrenAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.NavigationNodes
                .Include(n => n.Children)
                .Include(n => n.NavigationNodeRoles)
                    .ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(n => n.Id == id, cancellationToken);
        }

        public async Task<List<NavigationNodeDto>> GetNavigationsForRolesAsync(IList<string> roles, CancellationToken cancellationToken)
        {
            var allNodes = await _context.NavigationNodes
                .AsNoTracking()
                .Include(n => n.Children.Where(c => !c.IsDeleted))
                .Include(n => n.NavigationNodeRoles)
                    .ThenInclude(nr => nr.Role)
                .Where(n => n.IsActive &&
                            !n.IsDeleted &&
                            n.NavigationNodeRoles.Any(nr => roles.Contains(nr.Role.Name!)))
                .OrderBy(n => n.DisplayOrder)
                .ToListAsync(cancellationToken);

            // Only top-level nodes (ParentId == null)
            var rootNodes = allNodes.Where(n => n.ParentId == null).ToList();

            return rootNodes.Select(n => MapToDto(n, allNodes, roles)).ToList();
        }

        private NavigationNodeDto MapToDto(NavigationNode node, List<NavigationNode> allNodes, IList<string> roles)
        {
            return new NavigationNodeDto
            {
                Id = node.Id,
                Title = node.Title,
                Url = node.Url,
                IconUrl = node.IconUrl,
                DisplayOrder = node.DisplayOrder,
                IsActive = node.IsActive,
                Children = allNodes
                    .Where(c => c.ParentId == node.Id &&
                                c.NavigationNodeRoles.Any(r => roles.Contains(r.Role.Name!)))
                    .OrderBy(c => c.DisplayOrder)
                    .Select(c => MapToDto(c, allNodes, roles))
                    .ToList()
            };
        }
        public async Task<List<NavigationNodeDto>> GetTreeAsync(CancellationToken cancellationToken)
        {
            var nodes = await _context.NavigationNodes
                .AsNoTracking()
                .Where(n => !n.IsDeleted && n.IsActive)
                .OrderBy(n => n.DisplayOrder)
                .ToListAsync(cancellationToken);

            var lookup = nodes.ToLookup(n => n.ParentId);

            List<NavigationNodeDto> BuildTree(Guid? parentId)
            {
                return lookup[parentId]
                    .Select(n => new NavigationNodeDto
                    {
                        Id = n.Id,
                        Title = n.Title,
                        Url = n.Url,
                        IconUrl = n.IconUrl,
                        DisplayOrder = n.DisplayOrder,
                        ParentId = n.ParentId,
                        IsActive = n.IsActive,
                        //RoleIds = n.NavigationNodeRoles.Select(r => r.RoleId).ToList(),
                        Roles = n.NavigationNodeRoles
                        .Select(r => new RoleBindingDto
                        {
                            RoleId = r.RoleId,
                            RoleName = r.Role.Name ?? string.Empty // assuming NavigationNodeRole → Role navigation exists
                        }).ToList(),
                        Children = BuildTree(n.Id)
                    })
                    .ToList();
            }

            return BuildTree(null);
        }


        //public async Task<Guid> CreateWithRolesAsync(NavigationNode node, List<Guid> roleIds, CancellationToken cancellationToken)
        //{
        //    node.Id = Guid.NewGuid();

        //    foreach (var roleId in roleIds.Distinct())
        //    {
        //        node.NavigationNodeRoles.Add(new NavigationNodeRole
        //        {
        //            NavigationNodeId = node.Id,
        //            RoleId = roleId
        //        });
        //    }

        //    _context.NavigationNodes.Add(node);
        //    await _context.SaveChangesAsync(cancellationToken);

        //    // Add Role Mappings
        //    if (roleIds != null && roleIds.Any())
        //    {
        //        var roleMappings = roleIds.Select(rid => new NavigationNodeRole
        //        {
        //            NavigationNodeId = node.Id,
        //            RoleId = rid
        //        }).ToList();

        //        _context.NavigationNodeRoles.AddRange(roleMappings);
        //        await _context.SaveChangesAsync(cancellationToken);
        //    }

        //    return node.Id;
        //}

        public async Task<Guid> CreateWithRolesAsync(NavigationNode node, List<Guid> roleIds, CancellationToken cancellationToken)
        {
            node.Id = Guid.NewGuid();

            // Attach roles once
            foreach (var roleId in roleIds.Distinct())
            {
                node.NavigationNodeRoles.Add(new NavigationNodeRole
                {
                    NavigationNodeId = node.Id,
                    RoleId = roleId
                });
            }

            // Add node (EF Core will track roles automatically)
            _context.NavigationNodes.Add(node);
            await _context.SaveChangesAsync(cancellationToken);

            return node.Id;
        }


        public async Task<bool> ExistsAsync(Guid nodeId, CancellationToken cancellationToken)
        {
            return await _context.NavigationNodes
                .AnyAsync(x => x.Id == nodeId && !x.IsDeleted, cancellationToken);
        }
        public async Task UpdateWithRolesAsync(NavigationNode node, List<Guid> roleIds, CancellationToken cancellationToken)
        {
            var existingNode = await _context.NavigationNodes
                .Include(n => n.NavigationNodeRoles)
                .FirstOrDefaultAsync(n => n.Id == node.Id, cancellationToken)
                ?? throw new KeyNotFoundException("Navigation node not found");

            // Update scalar fields
            existingNode.Title = node.Title;
            existingNode.Url = node.Url;
            existingNode.IconUrl = node.IconUrl;
            existingNode.DisplayOrder = node.DisplayOrder;
            existingNode.ParentId = node.ParentId;

            // Update roles
            existingNode.NavigationNodeRoles.Clear();
            foreach (var roleId in roleIds.Distinct())
            {
                existingNode.NavigationNodeRoles.Add(new NavigationNodeRole
                {
                    NavigationNodeId = existingNode.Id,
                    RoleId = roleId
                });
            }

            await _context.SaveChangesAsync(cancellationToken);
        }

        //public async Task<List<NavigationNodeDto>> GetParentNodesAsync(CancellationToken cancellationToken)
        //{
        //    return await _context.NavigationNodes
        //        .Select(n => new NavigationNodeDto
        //        {
        //            Id = n.Id,
        //            Title = n.Title
        //        }).ToListAsync(cancellationToken);
        //}
        public async Task<List<NavigationNodeDropdownDto>> GetParentNodesAsync(Guid? excludeId, CancellationToken cancellationToken)
        {
            var query = _context.NavigationNodes
                .AsNoTracking()
                .Where(n => !n.IsDeleted && n.IsActive);

            // Exclude the current node
            if (excludeId.HasValue)
                query = query.Where(n => n.Id != excludeId.Value);

            return await query
                .Select(n => new NavigationNodeDropdownDto
                {
                    Id = n.Id,
                    Title = n.Title
                })
                .ToListAsync(cancellationToken);
        }


        public async Task<NavigationNodeDto?> GetNavigationByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.NavigationNodes
                .Include(n => n.NavigationNodeRoles)
                .Where(n => n.Id == id)
                .Select(n => new NavigationNodeDto
                {
                    Id = n.Id,
                    Title = n.Title,
                    Url = n.Url,
                    IconUrl = n.IconUrl,
                    DisplayOrder = n.DisplayOrder,
                    ParentId = n.ParentId,
                    //RoleIds = n.NavigationNodeRoles.Select(r => r.RoleId).ToList()
                    Roles = n.NavigationNodeRoles
                        .Select(r => new RoleBindingDto
                        {
                            RoleId = r.RoleId,
                            RoleName = r.Role.Name ?? string.Empty // assuming NavigationNodeRole → Role navigation exists
                        }).ToList(),
                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PaginatedResponse<NavigationNodeDto>?> GetAllAsync(QueryParams queryParams,
            CancellationToken cancellationToken)
        {
            var query = _context.NavigationNodes
                .Include(n => n.NavigationNodeRoles)
                .AsNoTracking()
                .Where(n => !n.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(n =>
                    n.Title.ToLower().Contains(search) ||
                    n.Url.ToLower().Contains(search)
                );
            }

            // Total count for pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "";
                query = query.OrderBy($"{column} {direction}");
            }
            else
            {
                query = query.OrderBy(n => n.DisplayOrder); // default sort
            }

            // Pagination
            var nodes = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .Select(n => new NavigationNodeDto
                {
                    Id = n.Id,
                    Title = n.Title,
                    Url = n.Url,
                    IconUrl = n.IconUrl,
                    DisplayOrder = n.DisplayOrder,
                    ParentId = n.ParentId,
                    IsActive = n.IsActive,
                    //RoleIds = n.NavigationNodeRoles.Select(r => r.RoleId).ToList(),
                    Roles = n.NavigationNodeRoles
                        .Select(r => new RoleBindingDto
                        {
                            RoleId = r.RoleId,
                            RoleName = r.Role.Name ?? string.Empty // assuming NavigationNodeRole → Role navigation exists
                        }).ToList(),
                    DateCreated = Helper.DateHelper.FormatDate(n.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(n.DateModified),
                    CreatedByName = n.CreatedByUserName ?? Defaults.Users.Unknown,
                    ModifiedByName = n.ModifiedByUserName ?? Defaults.Users.Unknown,
                })
                .ToListAsync(cancellationToken);

            // Build hierarchy (optional: only if UI expects nested tree)
            var hierarchicalData = BuildHierarchy(nodes);

            return new PaginatedResponse<NavigationNodeDto>
            {
                Data = hierarchicalData,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        private List<NavigationNodeDto> BuildHierarchy(List<NavigationNodeDto> nodes)
        {
            var lookup = nodes.ToLookup(n => n.ParentId);
            foreach (var node in nodes)
            {
                node.Children = lookup[node.Id].ToList();
            }
            return lookup[null].ToList();
        }
    }
}
