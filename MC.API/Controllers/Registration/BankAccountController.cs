using MC.Application.Features.Registration.Address.Command.Delete;
using MC.Application.Features.Registration.BankAccount.Command.Create;
using MC.Application.Features.Registration.BankAccount.Command.Update;
using MC.Application.Features.Registration.BankAccount.Query.GetById;
using MC.Application.Features.Registration.BankAccount.Query.GetActiveRecordByregistrationId;
using MC.Application.Features.Registration.BankAccount.Query.GetInactiveRecordByregistrationId;
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
        [HttpGet("get-active/{registrationId}")]
        public async Task<BankAccountDetailDto> Get(int registrationId)
        {
            var response = await _mediator.Send(new GetActiveRecordByregistrationIdQuery(registrationId));
            return response;
        }

        [HttpGet("get-all-inactive/{registrationId}")]
        public async Task<List<BankAccountDetailDto>> GetAllInactive(int registrationId)
        {
            var response = await _mediator.Send(new GetInactiveRecordByregistrationIdQuery(registrationId));
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccountDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetByIdBankAccountQuery(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateBankAccountCmd request)
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
        public async Task<ActionResult> Put(UpdateBankAccountCmd request)
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
