using MC.Application.Features.Menu.Menu.Command.Create;
using MC.Application.Features.Menu.Menu.Command.Delete;
using MC.Application.Features.Menu.Menu.Command.Update;
using MC.Application.Features.Menu.Menu.Query.GetAll;
using MC.Application.Features.Menu.Menu.Query.GetAllByTitle;
using MC.Application.Features.Menu.Menu.Query.GetById;
using MC.Application.ModelDto.Menu;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Menu
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<MenuDto>> Get(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllMenuQuery(), cancellationToken);
            return response;
        }

        [HttpGet("MenuTitle")]
        public async Task<List<MenuTitleDto>> GetMenuTitle(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllByTitleQuery(), cancellationToken);
            return response;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MenuDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByIdMenuQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateMenuCmd request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateMenuCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteMenuCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
