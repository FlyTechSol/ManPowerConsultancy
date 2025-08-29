using MC.Application.Features.Registration.Resignation.Query.GetById;
using MC.Application.Features.Registration.SecurityDeposit.Command.Create;
using MC.Application.Features.Registration.SecurityDeposit.Command.Delete;
using MC.Application.Features.Registration.SecurityDeposit.Command.Update;
using MC.Application.Features.Registration.SecurityDeposit.Query.GetById;
using MC.Application.Features.Registration.SecurityDeposit.Query.GetByRegistrationId;
using MC.Application.Features.Registration.SecurityDeposit.Query.GetByUserProfileId;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityDepositController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SecurityDepositController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SecurityDepositDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetSecurityDepositByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-security-deposit-by-registaration-id/{registrationId}")]
        public async Task<ActionResult<SecurityDepositDetailDto>> Get(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetSecurityDepositByRegistrationIdQuery(registrationId), cancellationToken);
            return response;
        }

        [HttpGet("get-security-deposit-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<SecurityDepositDetailDto>> GetSecurityDepositByUserProfile(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByUserProfileQuery(userProfileId), cancellationToken);
            return response;
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateSecurityDepositCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateSecurityDepositCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteSecurityDepositCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}