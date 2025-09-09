using MC.API.Resources;
using MC.Application.Features.Registration.PreviousExperience.Command.Create;
using MC.Application.Features.Registration.PreviousExperience.Command.Delete;
using MC.Application.Features.Registration.PreviousExperience.Command.Update;
using MC.Application.Features.Registration.PreviousExperience.Query.GetAll;
using MC.Application.Features.Registration.PreviousExperience.Query.GetById;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PreviousExperienceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PreviousExperienceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PreviousExperienceDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-all-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<PreviousExperienceDetailDto>>>> GetAllByUserProfile(Guid userProfileId, [FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllPreExpQuery(userProfileId, queryParams), cancellationToken);
            return Ok(response);
        }

        //[HttpGet("get-all-previous-exp-by-registration-id/{registrationId}")]
        //public async Task<ActionResult<List<PreviousExperienceDetailDto>>> GetAll(string registrationId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetAllByRegistrationIdQuery(registrationId), cancellationToken);
        //    return Ok(response);
        //}
        //[HttpGet("get-all-previous-exp-by-user-profile-id/{userProfileId}")]
        //public async Task<ActionResult<List<PreviousExperienceDetailDto>>> GetAllByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetAllByUserProfileQuery(userProfileId), cancellationToken);
        //    return Ok(response);
        //}
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreatePreviousExpCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdatePreviousExpCmd request, CancellationToken cancellationToken)
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
            var command = new DeletePreviousExpCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
