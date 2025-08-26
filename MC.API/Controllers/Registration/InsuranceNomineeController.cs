using MC.Application.Features.Registration.InsuranceNominee.Command.Create;
using MC.Application.Features.Registration.InsuranceNominee.Command.Delete;
using MC.Application.Features.Registration.InsuranceNominee.Command.Update;
using MC.Application.Features.Registration.InsuranceNominee.Query.GetAllByRegistrationId;
using MC.Application.Features.Registration.InsuranceNominee.Query.GetById;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceNomineeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InsuranceNomineeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceNomineeDetailDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetInsNomineeByIdQuery(id));
            return Ok(response);
        }

        [HttpGet("get-all-ex-army/{registrationId}")]
        public async Task<ActionResult<InsuranceNomineeDetailDto>> GetAll(int registrationId)
        {
            var response = await _mediator.Send(new GetAllInsNomineeByRegIdQuery(registrationId));
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateInsNomineeCmd request)
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
        public async Task<ActionResult> Put(UpdateInsNomineeCmd request)
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
            var command = new DeleteInsNomineeCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}