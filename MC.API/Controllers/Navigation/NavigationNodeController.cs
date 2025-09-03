using MC.Application.Features.Navigation.NavigationNode.Command.Create;
using MC.Application.Features.Navigation.NavigationNode.Command.Delete;
using MC.Application.Features.Navigation.NavigationNode.Command.Update;
using MC.Application.Features.Navigation.NavigationNode.Query.GetAll;
using MC.Application.Features.Navigation.NavigationNode.Query.GetById;
using MC.Application.Features.Navigation.NavigationNode.Query.GetNavigationsForRoles;
using MC.Application.Features.Navigation.NavigationNode.Query.GetNavigationTree;
using MC.Application.Features.Navigation.NavigationNode.Query.GetParentNavigationNodes;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Navigation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Navigation
{
    [ApiController]
    [Route("api/[controller]")]
    public class NavigationNodeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NavigationNodeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("dropdown")]
        public async Task<ActionResult<List<NavigationNodeDropdownDto>>> GetParentNodes(
        [FromQuery] Guid? excludeId,
        CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetParentNavigationNodesQuery(excludeId), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NavigationNodeDto>> GetNavigationById(
            Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetByIdNavigationNodeQuery(id), cancellationToken);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResponse<NavigationNodeDto>>> GetAll(
            [FromQuery] QueryParams queryParams,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllNavigationNodeQuery(queryParams), cancellationToken);
            return Ok(result);
        }

        [HttpGet("tree")]
        public async Task<ActionResult<List<NavigationNodeDto>>> GetTree(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetNavigationTreeQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<NavigationNodeDto>>> GetNavigationsForRoles(
            [FromQuery] List<string> roles,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetNavigationsForRolesQuery(roles), cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> CreateNavigationNode(
            CreateNavigationNodeCmd command,
            CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetNavigationById), new { id }, id);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateNavigationNode(
            Guid id,
            UpdateNavigationNodeCmd command,
            CancellationToken cancellationToken)
        {
            if (id != command.Id) return BadRequest("ID mismatch");
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteNavigationNodeCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

    }
}
