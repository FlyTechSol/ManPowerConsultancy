using MC.Application.Model.Identity.Roles;

namespace MC.Application.Contracts.Identity
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllRolesAsync();
        Task<Guid> CreateRolesAsync(CreateRoleDto request);
        Task<bool> UpdateRoleAsync(Guid roleId, RoleDto request);
        Task<bool> DeleteRoleAsync(Guid roleId);
    }
}
