using MC.Application.Features.Master.Title.Command.Create;
using MC.Application.Features.Master.Title.Command.Delete;
using MC.Application.Features.Master.Title.Command.Update;
using MC.Application.Features.Master.Title.Query.GetAll;
using MC.Application.Features.Master.Title.Query.GetById;
using MC.Application.ModelDto.Master.Master;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TitleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<TitleDto>> Get([FromQuery] bool? isMale)
        {
            var response = await _mediator.Send(new GetAllTitleQuery { IsMale = isMale });
            return response;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TitleDetailDto>> Get(Guid id)
        {
            var title = await _mediator.Send(new GetByIdTitleQuery(id));
            return Ok(title);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateTitleCmd title)
        {
            var response = await _mediator.Send(title);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateTitleCmd title)
        {
            await _mediator.Send(title);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTitleCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
