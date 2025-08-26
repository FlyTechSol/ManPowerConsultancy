using MC.Application.Features.Master.Document.Command.Create;
using MC.Application.Features.Master.Document.Command.Delete;
using MC.Application.Features.Master.Document.Command.Update;
using MC.Application.Features.Master.Document.Query.GetAll;
using MC.Application.Features.Master.Document.Query.GetAllAddressProof;
using MC.Application.Features.Master.Document.Query.GetAllAgeProof;
using MC.Application.Features.Master.Document.Query.GetAllIdentityProof;
using MC.Application.Features.Master.Document.Query.GetAllQualificationProof;
using MC.Application.Features.Master.Document.Query.GetById;
using MC.Application.ModelDto.Master.Master;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<DocumentDto>> Get()
        {
            var response = await _mediator.Send(new GetAllDocumentQuery());
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentDetailDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetByIdDocumentQuery(id));
            return Ok(response);
        }

        [HttpGet("get-all-identity-proof")]
        public async Task<ActionResult<DocumentDto>> GetAllIdentityDocument()
        {
            var response = await _mediator.Send(new GetAllIdentityProofQuery());
            return Ok(response);
        }

        [HttpGet("get-all-address-proof")]
        public async Task<ActionResult<DocumentDto>> GetAllAddressDocument()
        {
            var response = await _mediator.Send(new GetAllAddressProofQuery());
            return Ok(response);
        }

        [HttpGet("get-all-age-proof")]
        public async Task<ActionResult<DocumentDto>> GetAllAgeProofDocument()
        {
            var response = await _mediator.Send(new GetAllAgeProofQuery());
            return Ok(response);
        }

        [HttpGet("get-all-qualification-proof")]
        public async Task<ActionResult<DocumentDto>> GetAllQualificationDocument()
        {
            var response = await _mediator.Send(new GetAllQualificationProofQuery());
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateDocumentCmd request)
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
        public async Task<ActionResult> Put(UpdateDocumentCmd request)
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
            var command = new DeleteDocumentCmd { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}