using MC.Application.Features.Registration.GunMan.Command.Create;
using MC.Application.Features.Registration.GunMan.Command.Delete;
using MC.Application.Features.Registration.GunMan.Command.Update;
using MC.Application.Features.Registration.GunMan.Query.GetAllByRegistrationId;
using MC.Application.Features.Registration.GunMan.Query.GetById;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GunManController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GunManController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GunManDetailDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetGunManByIdQuery(id));
            return Ok(response);
        }

        [HttpGet("get-all-gun-men/{registrationId}")]
        public async Task<ActionResult<GunManDetailDto>> GetAll(string registrationId)
        {
            var response = await _mediator.Send(new GetAllGunManByRegIdQuery(registrationId));
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateGunManCmd request)
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
        public async Task<ActionResult> Put(UpdateGunManCmd request)
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
            var command = new DeleteGunManCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
