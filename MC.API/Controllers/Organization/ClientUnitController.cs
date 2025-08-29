using MC.Application.Features.Organization.ClientUnit.Command.Create;
using MC.Application.Features.Organization.ClientUnit.Command.Delete;
using MC.Application.Features.Organization.ClientUnit.Command.Update;
using MC.Application.Features.Organization.ClientUnit.Query.GetAll;
using MC.Application.Features.Organization.ClientUnit.Query.GetByClientMasterId;
using MC.Application.Features.Organization.ClientUnit.Query.GetById;
using MC.Application.ModelDto.Organization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Organization
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientUnitController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientUnitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnitDetailDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetUnitByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<UnitDetailDto>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllUnitQuery(), cancellationToken);
            return response;
        }

        [HttpGet("get-clinet-unit-by-client-master-id/{clientMasterId}")]
        public async Task<ActionResult<List<UnitDetailDto>>> GetByClientMasterId(Guid clientMasterId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetUnitByClientMasterQuery(clientMasterId), cancellationToken);
            return response;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateUnitCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateUnitCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteUnitCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
