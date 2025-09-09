using MC.API.Resources;
using MC.Application.Features.Registration.GunMan.Command.Create;
using MC.Application.Features.Registration.GunMan.Command.Delete;
using MC.Application.Features.Registration.GunMan.Command.Update;
using MC.Application.Features.Registration.GunMan.Query.GetAll;
using MC.Application.Features.Registration.GunMan.Query.GetById;
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
    public class GunManController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GunManController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GunManDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetGunManByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        [HttpGet("get-all-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<GunManDetailDto>>>> GetAllByUserProfile(Guid userProfileId, [FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllgunMenQuery(userProfileId, queryParams), cancellationToken);
            return Ok(response);
        }
        //[HttpGet("get-all-gun-men-by-registration-id/{registrationId}")]
        //public async Task<ActionResult<List<GunManDetailDto>>> GetAll(string registrationId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetAllGunManByRegIdQuery(registrationId), cancellationToken);
        //    return Ok(response);
        //}
        //[HttpGet("get-all-gun-men-by-user-profile-id/{userProfileId}")]
        //public async Task<ActionResult<List<GunManDetailDto>>> GetAllByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetAllByUserProfileQuery(userProfileId), cancellationToken);
        //    return Ok(response);
        //}
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateGunManCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateGunManCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteGunManCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
