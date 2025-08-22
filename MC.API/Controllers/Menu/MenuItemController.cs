using MC.Application.Features.Menu.MenuItem.Command.Create;
using MC.Application.Features.Menu.MenuItem.Command.Delete;
using MC.Application.Features.Menu.MenuItem.Command.Update;
using MC.Application.Features.Menu.MenuItem.Query.GetAll;
using MC.Application.Features.Menu.MenuItem.Query.GetById;
using MC.Application.Features.Menu.MenuItem.Query.GetMenuItemByMenuId;
using MC.Application.ModelDto.Menu;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Menu
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<MenuItemDto>> Get()
        {
            var response = await _mediator.Send(new GetAllMenuItemQuery());
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDetailDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetByIdMenuItemQuery(id));
            return Ok(response);
        }

        [HttpGet("MenuItemByMenuId/{menuId}")]
        public async Task<ActionResult<MenuItemDto>> GetMenuItemByMenuId(Guid menuId)
        {
            var response = await _mediator.Send(new GetMenuItemByMenuIdQuery(menuId));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateMenuItemCmd request)
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
        public async Task<ActionResult> Put(UpdateMenuItemCmd request)
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
            var command = new DeleteMenuItemCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
