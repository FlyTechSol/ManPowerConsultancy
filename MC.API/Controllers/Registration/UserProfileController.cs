using MC.API.Resources;
using MC.Application.Contracts.Identity;
using MC.Application.Features.Registration.UserProfile.Command.Create;
using MC.Application.Features.Registration.UserProfile.Command.Delete;
using MC.Application.Features.Registration.UserProfile.Command.Update;
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
        private readonly IUserContext _userContext;
        public UserProfileController(IMediator mediator, IUserContext userContext)
        {
            _mediator = mediator;
            _userContext = userContext;
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
            var userId = _userContext.UserGuidId;
            if (userId == Guid.Empty)
                throw new UnauthorizedAccessException("User not found.");

            request.LoggedInUser = userId;

            var response = await _mediator.Send(request, cancellationToken);
            //return CreatedAtAction(nameof(Get), new { registrationId = response });
            return CreatedAtAction(
                    nameof(GetById),
                    new { id = response },
                    ApiResponseMessage<Guid>.SuccessResponse(response, ResponseMessages.Created)
                    );
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(Guid id, UpdateUserProfileCmd request, CancellationToken cancellationToken)
        {
            request.Id = id;
            await _mediator.Send(request, cancellationToken);
            //return NoContent();
            return Ok(ApiResponseMessage<object>.SuccessResponse(null, ResponseMessages.Updated));
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
