using MC.Application.Features.Registration.PreviousExperience.Query.GetById;
using MC.Application.Features.Registration.Resignation.Command.Create;
using MC.Application.Features.Registration.Resignation.Command.Delete;
using MC.Application.Features.Registration.Resignation.Command.Update;
using MC.Application.Features.Registration.Resignation.Query.GetById;
using MC.Application.Features.Registration.Resignation.Query.GetByRegistrationId;
using MC.Application.Features.Registration.Resignation.Query.GetByUserProfileId;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResignationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ResignationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResignationDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetResignationByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-resignation-by-registration-id/{registrationId}")]
        public async Task<ActionResult<ResignationDetailDto>> Get(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByResignationIdQuery(registrationId), cancellationToken);
            return response;
        }
        [HttpGet("get-resignation-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<ResignationDetailDto>> GetResignationByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByUserProfileQuery(userProfileId), cancellationToken);
            return response;
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateResignationCmd request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = response }, null);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateResignationCmd request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteResignationCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}