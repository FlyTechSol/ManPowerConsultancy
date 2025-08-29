using MC.Application.Features.Registration.UserAsset.Command.Create;
using MC.Application.Features.Registration.UserAsset.Command.Delete;
using MC.Application.Features.Registration.UserAsset.Command.Update;
using MC.Application.Features.Registration.UserAsset.Query.GetAllByRegistrationId;
using MC.Application.Features.Registration.UserAsset.Query.GetById;
using MC.Application.ModelDto.Registration;
using MC.Application.Features.Registration.UserAsset.Query.GetAllByUserProfileId;
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
        public async Task<ActionResult<UserAssetDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByIdUserAssetQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-all-user-asset-by-registration-id/{registrationId}")]
        public async Task<ActionResult<List<UserAssetDetailDto>>> GetAll(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllUserAssetByRegIdQuery(registrationId), cancellationToken);
            return Ok(response);
        }
        [HttpGet("get-all-user-asset-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<List<UserAssetDetailDto>>> GetAllByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllByUserProfileQuery(userProfileId), cancellationToken);
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateUserAssetCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateUserAssetCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteUserAssetCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
