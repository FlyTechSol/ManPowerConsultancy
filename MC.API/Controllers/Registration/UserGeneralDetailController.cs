using MC.Application.Features.Registration.UserGeneralDetail.Command.Create;
using MC.Application.Features.Registration.UserGeneralDetail.Command.Delete;
using MC.Application.Features.Registration.UserGeneralDetail.Command.Update;
using MC.Application.Features.Registration.UserGeneralDetail.Query.GetByRegistrationId;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserGeneralDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserGeneralDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{registrationId}")]
        public async Task<UserGeneralDetailDto> Get(int registrationId)
        {
            var response = await _mediator.Send(new GetUserGeneralByRegistrationIdQuery(registrationId));
            return response;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateUserGeneralDetailCmd request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateUserGeneralDetailCmd request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteUserGeneralDetailCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
