using MC.API.Resources;
using MC.Application.Features.Registration.Training.Command.Create;
using MC.Application.Features.Registration.Training.Command.Delete;
using MC.Application.Features.Registration.Training.Command.Update;
using MC.Application.Features.Registration.Training.Query.GetAll;
using MC.Application.Features.Registration.Training.Query.GetById;
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
    public class TrainingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrainingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetTrainingByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        [HttpGet("get-all-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<TrainingDetailDto>>>> GetAllByUserProfile(Guid userProfileId, [FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllTrainingQuery(userProfileId, queryParams), cancellationToken);
            return Ok(response);
        }

        //[HttpGet("get-all-training-by-registration-id/{registrationId}")]
        //public async Task<ActionResult<List<TrainingDetailDto>>> GetAll(string registrationId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetAllTrainingByRegistrationIdQuery(registrationId), cancellationToken);
        //    return Ok(response);
        //}
        //[HttpGet("get-all-training-by-user-profile-id/{userProfileId}")]
        //public async Task<ActionResult<List<TrainingDetailDto>>> GetAllNyUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetAllByUserProfileQuery(userProfileId), cancellationToken);
        //    return Ok(response);
        //}
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateTrainingCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateTrainingCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteTrainingCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}