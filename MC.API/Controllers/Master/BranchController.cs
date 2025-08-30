using MC.Application.Features.Master.Branch.Command.Create;
using MC.Application.Features.Master.Branch.Command.Delete;
using MC.Application.Features.Master.Branch.Command.Update;
using MC.Application.Features.Master.Branch.Query.GetAll;
using MC.Application.Features.Master.Branch.Query.GetById;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<BranchDetailDto>>>> GetAll([FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllBranchesQuery(queryParams), cancellationToken);
            return Ok(response);
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchDetailDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetBranchByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateBranchCmd request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = response }, null);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateBranchCmd request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteBranchCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
