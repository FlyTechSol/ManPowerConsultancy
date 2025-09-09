using MC.API.Resources;
using MC.Application.Features.Registration.Insurance.Query.GetById;
using MC.Application.Features.Registration.PoliceVerification.Command.Create;
using MC.Application.Features.Registration.PoliceVerification.Command.Delete;
using MC.Application.Features.Registration.PoliceVerification.Command.Update;
using MC.Application.Features.Registration.PoliceVerification.Query.GetById;
using MC.Application.Features.Registration.PoliceVerification.Query.GetByRegistrationId;
using MC.Application.Features.Registration.PoliceVerification.Query.GetByUserProfileId;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceVerificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PoliceVerificationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PoliceVerificationDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetPoliceVeriByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        //[HttpGet("get-police-verification-by-registration-id/{registrationId}")]
        //public async Task<ActionResult<PoliceVerificationDetailDto>> GetPoliceVerificationByRegId(string registrationId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetPoliceVeriByRegistrationIdQuery(registrationId), cancellationToken);
        //    return response;
        //}
        [HttpGet("get-all-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<PoliceVerificationDetailDto>> GetPoliceVerificationByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByUserProfileQuery(userProfileId), cancellationToken);
            return response;
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreatePoliceVeriCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdatePoliceVeriCmd request, CancellationToken cancellationToken)
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
            var command = new DeletePoliceVeriCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
