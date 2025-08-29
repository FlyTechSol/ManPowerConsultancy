using MC.Application.Features.Master.Bank.Command.Create;
using MC.Application.Features.Master.Bank.Command.Delete;
using MC.Application.Features.Master.Bank.Command.Update;
using MC.Application.Features.Master.Bank.Query.GetAll;
using MC.Application.Features.Master.Bank.Query.GetById;
using MC.Application.ModelDto.Master.Master;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BankController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BankDto>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllBankQuery(), cancellationToken);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankDetailDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByIdBankQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateBankCmd request, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Put(UpdateBankCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteBankCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
