using MC.Application.Features.Master.Religion.Command.Create;
using MC.Application.Features.Master.Religion.Command.Delete;
using MC.Application.Features.Master.Religion.Command.Update;
using MC.Application.Features.Master.Religion.Query.GetAll;
using MC.Application.Features.Master.Religion.Query.GetById;
using MC.Application.ModelDto.Master.Master;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReligionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReligionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ReligionDto>> Get()
        {
            var response = await _mediator.Send(new GetAllReligionQuery());
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReligionDetailDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetByIdReligionQuery(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateReligionCmd request)
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
        public async Task<ActionResult> Put(UpdateReligionCmd request)
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
            var command = new DeleteReligionCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}