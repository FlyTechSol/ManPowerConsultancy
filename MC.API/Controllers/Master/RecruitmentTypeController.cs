using MC.Application.Features.Master.RecruitmentType.Command.Create;
using MC.Application.Features.Master.RecruitmentType.Command.Delete;
using MC.Application.Features.Master.RecruitmentType.Command.Update;
using MC.Application.Features.Master.RecruitmentType.Query.GetAll;
using MC.Application.Features.Master.RecruitmentType.Query.GetById;
using MC.Application.ModelDto.Master.Master;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RecruitmentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<RecruitmentTypeDto>> Get()
        {
            var response = await _mediator.Send(new GetAllRecruitmentTypeQuery());
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecruitmentTypeDetailDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetByIdRecruitmentTypeQuery(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateRecruitmentTypeCmd request)
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
        public async Task<ActionResult> Put(UpdateRecruitmentTypeCmd request)
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
            var command = new DeleteRecruitmentTypeCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
