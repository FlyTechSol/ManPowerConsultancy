using MC.API.Resources;
using MC.Application.Features.Registration.Address.Query.GetAll;
using MC.Application.Features.Registration.Insurance.Command.Create;
using MC.Application.Features.Registration.Insurance.Command.Delete;
using MC.Application.Features.Registration.Insurance.Command.Update;
using MC.Application.Features.Registration.Insurance.Query.GetById;
using MC.Application.Features.Registration.Insurance.Query.GetByRegistrationId;
using MC.Application.Features.Registration.Insurance.Query.GetByUserProfileId;
using MC.Application.Features.Registration.InsuranceNominee.Query.GetAll;
using MC.Application.Features.Registration.InsuranceNominee.Query.GetById;
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
    public class InsuranceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InsuranceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetInsuranceByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        [HttpGet("get-all-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<InsuranceDetailDto>>>> GetAllByUserProfile(Guid userProfileId, [FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllInsNomineeQuery(userProfileId, queryParams), cancellationToken);
            return Ok(response);
        }

        //[HttpGet("get-insurance-by-registration-id/{registrationId}")]
        //public async Task<ActionResult<List<InsuranceDetailDto>>> Get(string registrationId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetByRegistrationIdInsuranceQuery(registrationId), cancellationToken);
        //    return response;
        //}
        //[HttpGet("get-insurance-by-user-profile-id/{userProfileId}")]
        //public async Task<ActionResult<List<InsuranceDetailDto>>> GetInsuranceByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetByUserProfileQuery(userProfileId), cancellationToken);
        //    return response;
        //}
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateInsuranceCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateInsuranceCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteInsuranceCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}

