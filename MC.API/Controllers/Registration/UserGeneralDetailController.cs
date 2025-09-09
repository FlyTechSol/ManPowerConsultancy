using MC.API.Resources;
using MC.Application.Features.Registration.UserAsset.Query.GetById;
using MC.Application.Features.Registration.UserGeneralDetail.Command.Create;
using MC.Application.Features.Registration.UserGeneralDetail.Command.Delete;
using MC.Application.Features.Registration.UserGeneralDetail.Command.Update;
using MC.Application.Features.Registration.UserGeneralDetail.Query.GetById;
using MC.Application.Features.Registration.UserGeneralDetail.Query.GetByRegistrationId;
using MC.Application.Features.Registration.UserGeneralDetail.Query.GetByUserProfileId;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserGeneralDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserGeneralDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGeneralDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetUserGeneralByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        //[HttpGet("get-general-detail-by-registration-id/{registrationId}")]
        //public async Task<ActionResult<UserGeneralDetailDto>> GetByRegistrationId(string registrationId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetUserGeneralByRegistrationIdQuery(registrationId), cancellationToken);
        //    return response;
        //}

        [HttpGet("get-all-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<UserGeneralDetailDto>> GetGeneralDetailByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetUserGeneralByUserProfileIdQuery(userProfileId), cancellationToken);
            return response;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateUserGeneralDetailCmd request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            //return CreatedAtAction(nameof(Get), new { id = response }, null);
            return CreatedAtAction(
                     nameof(Get),
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
        public async Task<ActionResult> Put(UpdateUserGeneralDetailCmd request, CancellationToken cancellationToken)
        {
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
            var command = new DeleteUserGeneralDetailCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
