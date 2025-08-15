using MC.Application.Contracts.Identity;
using MC.Application.Model.Identity.Roles;
using MC.Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public RoleService(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<List<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.Cast<ApplicationRole>().ToListAsync();
            return roles.Select(role => new RoleDto
            {
                Id = role.Id,
                DisplayOrder = role.DisplayOrder,
                Name = role.Name ?? string.Empty
            }).ToList();
        }

        public async Task<Guid> CreateRolesAsync(CreateRoleDto request)
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
        public async Task<bool> UpdateRoleAsync(Guid roleId, RoleDto request)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString()) as ApplicationRole; 

            if (role == null) return false;

            role.Name = request.Name;
            role.DisplayOrder = request.DisplayOrder; 

            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }
        public async Task<bool> DeleteRoleAsync(Guid roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null) return false;

            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }
    }
}