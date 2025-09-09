using MC.API.Resources;
using MC.Application.Features.Registration.ExArmy.Command.Create;
using MC.Application.Features.Registration.ExArmy.Command.Delete;
using MC.Application.Features.Registration.ExArmy.Command.Update;
using MC.Application.Features.Registration.ExArmy.Query.GetAllByRegistrationId;
using MC.Application.Features.Registration.ExArmy.Query.GetAllByUserProfileId;
using MC.Application.Features.Registration.ExArmy.Query.GetById;
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
    public class ExArmyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExArmyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ExArmyDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetExArmyByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-all-by-registration-id/{registrationId}")]
        public async Task<ActionResult<ExArmyDetailDto>> GetAll(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllByRegistrationIdQuery(registrationId), cancellationToken);
            return Ok(response);
        }
        [HttpGet("get-all-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<ExArmyDetailDto>>>> GetAllexArmyByUserProfile(Guid userProfileId, [FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllByUserProfileIdQuery(userProfileId, queryParams), cancellationToken);
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateExArmyCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateExArmyCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteExArmyCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
