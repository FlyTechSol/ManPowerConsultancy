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
        public async Task<List<ZipCodeDto>> Get()
        {
            var response = await _mediator.Send(new GetAllZipCodeQuery());
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZipCodeDetailDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetByIdZipCodeQuery(id));
            return Ok(response);
        }

        [HttpGet("get-location-by-zipcode/{zipCode}")]
        public async Task<ActionResult<ZipCodeDto>> GetLocationByZipCode(string zipCode)
        {
            var response = await _mediator.Send(new GetByZipCodeQuery(zipCode));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateZipCodeCmd request)
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
        public async Task<ActionResult> Put(UpdateZipCodeCmd request)
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
            var command = new DeleteZipCodeCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
