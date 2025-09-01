using MC.Application.Contracts.Identity;
using MC.Application.Model.Identity.Roles;
using MC.Application.ModelDto.Common.Pagination;
using MC.Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public RoleService(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<PaginatedResponse<RoleDto>> GetAllRolesAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _roleManager.Roles
                .AsQueryable()
                .Cast<ApplicationRole>();

            // Optional search (if query string is provided)
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(r => r.Name != null && r.Name.ToLower().Contains(search));
            }

            // Total count before pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Dynamic sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                var direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "ascending";
                query = query.OrderBy($"{queryParams.Column} {direction}");
            }
            else
            {
                query = query.OrderBy(r => r.DisplayOrder); // Default sort
            }

            // Apply pagination
            var roles = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            // Map to DTO
            var dtos = roles.Select(role => new RoleDto
            {
                Id = role.Id,
                Name = role.Name ?? string.Empty,
                DisplayOrder = role.DisplayOrder
            }).ToList();

            return new PaginatedResponse<RoleDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }


        public async Task<Guid> CreateRolesAsync(CreateRoleDto request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Role name cannot be empty");

            // Check if the role already exists
            var existingRole = await _roleManager.FindByNameAsync(request.Name);
            if (existingRole != null)
                throw new InvalidOperationException("Role already exists");

            // Create a new role with ApplicationRole instead of IdentityRole
            var role = new ApplicationRole
            {
                Id = Guid.NewGuid(), // Ensuring a valid GUID-based ID
                Name = request.Name,
                DisplayOrder = request.DisplayOrder 
            };

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
                throw new InvalidOperationException("Failed to create role");

            return role.Id;
        }
        public async Task<bool> UpdateRoleAsync(Guid roleId, RoleDto request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());

            if (role is not ApplicationRole appRole)
                return false;

            appRole.Name = request.Name;
            appRole.DisplayOrder = request.DisplayOrder;

            var result = await _roleManager.UpdateAsync(appRole);
            return result.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(Guid roleId, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
                return false;

            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

    }
}