using MC.Application.Features.Master.Gender.Query.GetAll;
using MC.Application.Features.Master.Gender.Query.GetById;
using MC.Application.Features.Registration.UserGeneralDetail.Command.Create;
using MC.Application.Features.Registration.UserGeneralDetail.Command.Delete;
using MC.Application.Features.Registration.UserGeneralDetail.Command.Update;
using MC.Application.Features.Registration.UserProfile.Command.Create;
using MC.Application.Features.Registration.UserProfile.Command.Delete;
using MC.Application.Features.Registration.UserProfile.Query.GetAll;
using MC.Application.Features.Registration.UserProfile.Query.GetById;
using MC.Application.Features.Registration.UserProfile.Query.GetByRegistrationId;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<UserProfileDto>>>> GetAll([FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllUserProfilesQuery(queryParams), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserProfileDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetUserProfileByIdQuery(id), cancellationToken);
            if (response == null)
                return NotFound();

            return Ok(response);
        }
        [HttpGet("registration-id/{registrationId}")]
        public async Task<ActionResult<GenderDetailDto>> Get(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetUserProfileByRegistrationIdQuery(registrationId), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateUserProfileCmd request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return CreatedAtAction(nameof(Get), new { registrationId = response });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateUserGeneralDetailCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteUserProfileCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

    }
}
