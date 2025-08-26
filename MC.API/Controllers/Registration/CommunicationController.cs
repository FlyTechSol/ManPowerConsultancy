using MC.Application.Features.Registration.Communication.Command.Create;
using MC.Application.Features.Registration.Communication.Command.Delete;
using MC.Application.Features.Registration.Communication.Command.Update;
using MC.Application.Features.Registration.Communication.Query.GetByRegistrationId;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommunicationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{registrationId}")]
        public async Task<CommunicationDetailDto> Get(int registrationId)
        {
            var response = await _mediator.Send(new GetByRegistrationIdCommunicationQuery(registrationId));
            return response;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateCommunicationCmd request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCommunicationCmd request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteCommunicationCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
