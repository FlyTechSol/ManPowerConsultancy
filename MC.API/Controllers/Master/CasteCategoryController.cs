using MC.Application.Features.Master.CasteCategory.Command.Create;
using MC.Application.Features.Master.CasteCategory.Command.Delete;
using MC.Application.Features.Master.CasteCategory.Command.Update;
using MC.Application.Features.Master.CasteCategory.Query.GetAll;
using MC.Application.Features.Master.CasteCategory.Query.GetById;
using MC.Application.ModelDto.Master.Master;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CasteCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CasteCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CasteCategoryDto>> Get()
        {
            var response = await _mediator.Send(new GetAllCasteCategoryQuery());
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CasteCategoryDetailDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetByIdCasteCategoryQuery(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateCasteCategoryCmd request)
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
        public async Task<ActionResult> Put(UpdateCasteCategoryCmd request)
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
            var command = new DeleteCasteCategoryCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
