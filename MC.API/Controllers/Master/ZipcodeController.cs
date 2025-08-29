using MC.Application.Features.Master.ZipCode.Command.Create;
using MC.Application.Features.Master.ZipCode.Command.Delete;
using MC.Application.Features.Master.ZipCode.Command.Update;
using MC.Application.Features.Master.ZipCode.Query.GetAll;
using MC.Application.Features.Master.ZipCode.Query.GetById;
using MC.Application.Features.Master.ZipCode.Query.GetByZipCode;
using MC.Application.ModelDto.Master.Master;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ZipcodeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ZipcodeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<ZipCodeDto>>> Get(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllZipCodeQuery(), cancellationToken);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZipCodeDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByIdZipCodeQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-location-by-zipcode/{zipCode}")]
        public async Task<ActionResult<ZipCodeDto>> GetLocationByZipCode(string zipCode, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByZipCodeQuery(zipCode), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateZipCodeCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateZipCodeCmd request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteZipCodeCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
