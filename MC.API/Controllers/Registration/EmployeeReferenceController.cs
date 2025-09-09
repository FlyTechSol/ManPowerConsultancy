using MC.API.Resources;
using MC.Application.Features.Registration.Address.Query.GetAll;
using MC.Application.Features.Registration.EmployeeReference.Command.Create;
using MC.Application.Features.Registration.EmployeeReference.Command.Delete;
using MC.Application.Features.Registration.EmployeeReference.Command.Update;
using MC.Application.Features.Registration.EmployeeReference.Query.GetAll;
using MC.Application.Features.Registration.EmployeeReference.Query.GetAllByRegistrationId;
using MC.Application.Features.Registration.EmployeeReference.Query.GetAllByUserProfileId;
using MC.Application.Features.Registration.EmployeeReference.Query.GetById;
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
    public class EmployeeReferenceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeReferenceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeReferenceDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetEmpRefByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        [HttpGet("get-all-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<EmployeeReferenceDetailDto>>>> GetAllempRefByUserProfile(Guid userProfileId, [FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllEmpRefQuery(userProfileId, queryParams), cancellationToken);
            return Ok(response);
        }

        //[HttpGet("get-all-by-registration-id/{registrationId}")]
        //public async Task<ActionResult<List<EmployeeReferenceDetailDto>>> GetAll(string registrationId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetAllEmpRefByRegistrationIdQuery(registrationId), cancellationToken);
        //    return response;
        //}

        //[HttpGet("get-all-emp-ref-by-user-profile-id/{userProfileId}")]
        //public async Task<ActionResult<List<EmployeeReferenceDetailDto>>> GetAllempRefByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetAllByUserProfileIdQuery(userProfileId), cancellationToken);
        //    return response;
        //}

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateEmpRefCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateEmpRefCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteEmpRefCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}