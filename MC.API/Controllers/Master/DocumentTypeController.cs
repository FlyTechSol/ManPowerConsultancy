using MC.API.Resources;
using MC.Application.Features.Master.DocumentType.Command.Create;
using MC.Application.Features.Master.DocumentType.Command.Delete;
using MC.Application.Features.Master.DocumentType.Command.Update;
using MC.Application.Features.Master.DocumentType.Query.GetAll;
using MC.Application.Features.Master.DocumentType.Query.GetAllByPurpose;
using MC.Application.Features.Master.DocumentType.Query.GetById;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Enum.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DocumentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<DocumentTypeDetailDto>>>> GetAll([FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllDocumentTypeQuery(queryParams), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentTypeDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByIdDocumentTypeQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("purpose/{purpose}")]
        [ProducesResponseType(typeof(List<DocumentTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByPurpose([FromRoute] DocumentPurpose purpose, [FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            // Now we're passing both purpose and queryParams explicitly to the query
            var query = new GetAllByPurposeQuery(queryParams, purpose);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateDocumentTypeCmd request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return CreatedAtAction(
                      nameof(Get),
                      new { id = response },
                      ApiResponseMessage<Guid>.SuccessResponse(response, ResponseMessages.Created)
                      );
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateDocumentTypeCmd request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            //return NoContent();
            return Ok(ApiResponseMessage<object>.SuccessResponse(null, ResponseMessages.Updated));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteDocumentTypeCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}