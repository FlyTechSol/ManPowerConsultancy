using MC.Application.Features.Master.Asset.Command.Create;
using MC.Application.Features.Master.Asset.Command.Delete;
using MC.Application.Features.Master.Asset.Command.Update;
using MC.Application.Features.Master.Asset.Query.GetAll;
using MC.Application.Features.Master.Asset.Query.GetById;
using MC.Application.ModelDto.Master.Master;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AssetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AssetDto>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllAssetQuery(), cancellationToken);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDetailDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByIdAssetQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateAssetCmd request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = response }, null);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateAssetCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteAssetCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
