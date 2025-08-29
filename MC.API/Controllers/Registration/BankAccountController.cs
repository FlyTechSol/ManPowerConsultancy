using MC.Application.Features.Registration.Address.Command.Delete;
using MC.Application.Features.Registration.BankAccount.Command.Create;
using MC.Application.Features.Registration.BankAccount.Command.Update;
using MC.Application.Features.Registration.BankAccount.Query.GetById;
using MC.Application.Features.Registration.BankAccount.Query.GetActiveRecordByregistrationId;
using MC.Application.Features.Registration.BankAccount.Query.GetInactiveRecordByregistrationId;
using MC.Application.Features.Registration.BankAccount.Query.GetActiveRecordByUserProfileId;
using MC.Application.Features.Registration.BankAccount.Query.GetInactiveRecordByUserProfileId;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-active-by-registration-id/{registrationId}")]
        public async Task<ActionResult<BankAccountDetailDto>> GetActiveByRegistrationId(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetActiveRecordByregistrationIdQuery(registrationId), cancellationToken);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("get-all-inactive-by-registration-id/{registrationId}")]
        public async Task<ActionResult<List<BankAccountDetailDto>>> GetAllInactiveByRegistrationId(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetInactiveRecordByregistrationIdQuery(registrationId), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-active-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<BankAccountDetailDto>> GetActiveByUserProfileId(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetActiveRecordByUserProfileIdQuery(userProfileId), cancellationToken);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("get-all-inactive-by-user-profile-id/{userProfileId}")] 
        public async Task<ActionResult<List<BankAccountDetailDto>>> GetAllInactiveByUserProfileId(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetInactiveRecordByUserProfileIdQuery(userProfileId), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccountDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByIdBankAccountQuery(id), cancellationToken);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateBankAccountCmd request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = response }, null); 
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateBankAccountCmd request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteAddressCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}

