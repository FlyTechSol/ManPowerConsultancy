using MC.Application.Features.Organization.ClientMaster.Command.Create;
using MC.Application.Features.Organization.ClientMaster.Command.Delete;
using MC.Application.Features.Organization.ClientMaster.Command.Update;
using MC.Application.Features.Organization.ClientMaster.Query.GetAll;
using MC.Application.Features.Organization.ClientMaster.Query.GetByCompanyId;
using MC.Application.Features.Organization.ClientMaster.Query.GetById;
using MC.Application.ModelDto.Organization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Organization
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientMasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientMasterDetailDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetClientMasterByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientMasterDetailDto>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllClientMasterQuery(), cancellationToken);
            return response;
        }

        [HttpGet("get-clinet-master-by-company-id/{companyId}")]
        public async Task<ActionResult<List<ClientMasterDetailDto>>> GetByClientMasterId(Guid companyId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetClientMasterByCompanyIdQuery(companyId), cancellationToken);
            return response;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateClientMasterCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateClientMasterCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteClientMasterCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
