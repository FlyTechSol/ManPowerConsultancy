using MC.API.Resources;
using MC.Application.Features.Registration.Address.Query.GetAll;
using MC.Application.Features.Registration.Family.Command.Create;
using MC.Application.Features.Registration.Family.Command.Delete;
using MC.Application.Features.Registration.Family.Command.Update;
using MC.Application.Features.Registration.Family.Query.GetAll;
using MC.Application.Features.Registration.Family.Query.GetAllByRegistrationId;
using MC.Application.Features.Registration.Family.Query.GetAllByUserProfileId;
using MC.Application.Features.Registration.Family.Query.GetById;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FamilyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetFamilyByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-all-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<FamilyDetailDto>>>> GetAllByUserProfile(Guid userProfileId, [FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllFamiliesQuery(userProfileId, queryParams), cancellationToken);
            return Ok(response);
        }


        //[HttpGet("get-all-family-by-registration-id/{registrationId}")]
        //public async Task<ActionResult<List<FamilyDetailDto>>> GetAll(string registrationId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetAllByRegistrationIdQuery(registrationId), cancellationToken);
        //    return Ok(response);
        //}
        //[HttpGet("get-all-family-by-user-profile-id/{userProfileId}")]
        //public async Task<ActionResult<List<FamilyDetailDto>>> GetAllFamilyByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetAllByUserProfileQuery(userProfileId), cancellationToken);
        //    return Ok(response);
        //}
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateFamilyCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateFamilyCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteFamilyCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
