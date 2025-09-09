using MC.API.Resources;
using MC.Application.Features.Registration.BodyMeasurement.Command.Create;
using MC.Application.Features.Registration.BodyMeasurement.Command.Delete;
using MC.Application.Features.Registration.BodyMeasurement.Command.Update;
using MC.Application.Features.Registration.BodyMeasurement.Query.GetById;
using MC.Application.Features.Registration.BodyMeasurement.Query.GetByRegistrationId;
using MC.Application.Features.Registration.BodyMeasurement.Query.GetByUserProfileId;
using MC.Application.Features.Registration.Communication.Query.GetById;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BodyMeasurementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BodyMeasurementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyMeasurementDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetBodyMeasurementByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-by-registration-id/{registrationId}")]
        public async Task<ActionResult<BodyMeasurementDetailDto>> GetBodyMeasurementByRegistrationId(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByRegistrationIdBodyMeasQuery(registrationId), cancellationToken);
            return response;
        }

        [HttpGet("get-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<BodyMeasurementDetailDto>> GetBodyMeasurementByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByUserProfileIdQuery(userProfileId), cancellationToken);
            return response;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateBodyMeasCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateBodyMeasCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteBodyMeasCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}