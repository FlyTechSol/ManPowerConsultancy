using MC.Application.Model.Identity.Roles;
using MC.Application.ModelDto.Common.Pagination;

namespace MC.Application.Contracts.Identity
{
    public interface IRoleService
    {
        Task<PaginatedResponse<RoleDto>> GetAllRolesAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<Guid> CreateRolesAsync(CreateRoleDto request, CancellationToken cancellationToken);
        Task<bool> UpdateRoleAsync(Guid roleId, RoleDto request, CancellationToken cancellationToken);
        Task<bool> DeleteRoleAsync(Guid roleId, CancellationToken cancellationToken);
    }
}
