using MC.Application.Features.Registration.Family.Command.Create;
using MC.Application.Features.Registration.Family.Command.Delete;
using MC.Application.Features.Registration.Family.Command.Update;
using MC.Application.Features.Registration.Family.Query.GetById;
using MC.Application.Features.Registration.Family.Query.GetAllByRegistrationId;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FamilyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyDetailDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetFamilyByIdQuery(id));
            return Ok(response);
        }

        [HttpGet("get-all-ex-army/{registrationId}")]
        public async Task<ActionResult<FamilyDetailDto>> GetAll(string registrationId)
        {
            var response = await _mediator.Send(new GetAllByRegistrationIdQuery(registrationId));
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateFamilyCmd request)
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
        public async Task<ActionResult> Put(UpdateFamilyCmd request)
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
            var command = new DeleteFamilyCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
