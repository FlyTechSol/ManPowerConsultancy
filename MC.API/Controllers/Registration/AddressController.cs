using MC.Application.Features.Registration.Address.Command.Create;
using MC.Application.Features.Registration.Address.Command.Delete;
using MC.Application.Features.Registration.Address.Command.Update;
using MC.Application.Features.Registration.Address.Query.GetActiveRecordByregistrationId;
using MC.Application.Features.Registration.Address.Query.GetByAddressId;
using MC.Application.Features.Registration.Address.Query.GetInactiveRecordByregistrationId;
using MC.Application.Features.Registration.Address.Query.GetInactiveRecordByUserProfileId;
using MC.Application.Features.Registration.Address.Query.GetActiveRecordByUserProfileId;
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
        public async Task<ActionResult<AddressDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByAddressIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-active-address-registration/{registrationId}")]
        public async Task<ActionResult<AddressDetailDto>> GetActiveAddressByRegistrationId(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetActiveRecordByregistrationIdQuery(registrationId), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-inactive-address-registration/{registrationId}")]
        public async Task<ActionResult<List<AddressDetailDto>>> GetInactiveAddressByRegistrationId(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetInactiveRecordByregistrationIdQuery(registrationId), cancellationToken);
            return response;
        }
        [HttpGet("get-active-address-user-profile/{userProfileId}")]
        public async Task<ActionResult<AddressDetailDto>> GetActiveAddressByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetActiveRecordByUserProfileIdQuery(userProfileId), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-inactive-address-user-profile/{userProfileId}")]
        public async Task<ActionResult<List<AddressDetailDto>>> GetInactiveAddressByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetInactiveRecordByUserProfileIdQuery(userProfileId), cancellationToken);
            return response;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateAddressCmd request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = response }, null);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateAddressCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteAddressCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
