using MC.Application.Features.Registration.UserAsset.Command.Create;
using MC.Application.Features.Registration.UserAsset.Command.Delete;
using MC.Application.Features.Registration.UserAsset.Command.Update;
using MC.Application.Features.Registration.UserAsset.Query.GetAllByRegistrationId;
using MC.Application.Features.Registration.UserAsset.Query.GetById;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAssetController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserAssetController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAssetDetailDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetByIdUserAssetQuery(id));
            return Ok(response);
        }

        [HttpGet("get-all-user-asset/{registrationId}")]
        public async Task<ActionResult<UserAssetDetailDto>> GetAll(string registrationId)
        {
            var response = await _mediator.Send(new GetAllUserAssetByRegIdQuery(registrationId));
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateUserAssetCmd request)
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
        public async Task<ActionResult> Put(UpdateUserAssetCmd request)
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
            var command = new DeleteUserAssetCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
