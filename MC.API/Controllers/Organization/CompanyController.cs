using MC.API.Resources;
using MC.Application.Features.Organization.Company.Command.Create;
using MC.Application.Features.Organization.Company.Command.Delete;
using MC.Application.Features.Organization.Company.Command.Update;
using MC.Application.Features.Organization.Company.Query.GetAll;
using MC.Application.Features.Organization.Company.Query.GetById;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Organization
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetailDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetCompanyByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<CompanyDetailDto>>>> GetAll([FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllCompanyQuery(queryParams), cancellationToken);
            return Ok(response);
        }
               
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateCompanyCmd request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            //return CreatedAtAction(nameof(GetById), new { id = response }, null);
            return CreatedAtAction(
                      nameof(GetById),
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
        public async Task<ActionResult> Put(UpdateCompanyCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteCompanyCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
