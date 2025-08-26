using MC.Application.Features.Registration.Address.Command.Create;
using MC.Application.Features.Registration.Address.Command.Delete;
using MC.Application.Features.Registration.Address.Command.Update;
using MC.Application.Features.Registration.Address.Query.GetActiveRecordByregistrationId;
using MC.Application.Features.Registration.Address.Query.GetByAddressId;
using MC.Application.Features.Registration.Address.Query.GetInactiveRecordByregistrationId;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDetailDto>> Get(Guid userId)
        {
            var response = await _mediator.Send(new GetByAddressIdQuery(userId));
            return Ok(response);
        }

        [HttpGet("get-active-address/{registrationId}")]
        public async Task<ActionResult<AddressDetailDto>> GetActiveAddress(int registrationId)
        {
            var response = await _mediator.Send(new GetActiveRecordByregistrationIdQuery(registrationId));
            return Ok(response);
        }

        [HttpGet("get-inactive-address/{registrationId}")]
        public async Task<ActionResult<AddressDetailDto>> GetInactiveAddress(int registrationId)
        {
            var response = await _mediator.Send(new GetInactiveRecordByregistrationIdQuery(registrationId));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateAddressCmd request)
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
        public async Task<ActionResult> Put(UpdateAddressCmd request)
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
            var command = new DeleteAddressCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
