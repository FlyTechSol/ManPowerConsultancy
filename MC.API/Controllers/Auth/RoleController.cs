using MC.Application.Contracts.Identity;
using MC.Application.Model.Identity.Roles;
using MC.Application.ModelDto.Common.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Auth
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleDto>>> GetAllRoles([FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetAllRolesAsync(queryParams, cancellationToken);
            return Ok(roles);
        }

        [HttpPost("new-role")]
        public async Task<ActionResult<Guid>> CreateRolesAsync([FromBody] CreateRoleDto request, CancellationToken cancellationToken)
        {
            var roleId = await _roleService.CreateRolesAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetAllRoles), new { id = roleId }, roleId);
        }

        [HttpPut("{roleId}")] // Ensure URL parameter matches method parameter
        public async Task<ActionResult<bool>> UpdateRoleAsync([FromRoute] Guid roleId, [FromBody] RoleDto request, CancellationToken cancellationToken)
        {
            var updated = await _roleService.UpdateRoleAsync(roleId, request, cancellationToken);
            if (!updated) return NotFound("Role not found.");

            return Ok(updated);
        }

        [HttpDelete("{roleId}")] // Ensure URL parameter matches method parameter
        public async Task<ActionResult<bool>> DeleteRoleAsync([FromRoute] Guid roleId, CancellationToken cancellationToken)
        {
            var deleted = await _roleService.DeleteRoleAsync(roleId, cancellationToken);
            if (!deleted) return NotFound("Role not found.");

            return Ok(deleted);
        }
    }
}
