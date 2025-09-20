using MC.API.Resources;
using MC.Application.Features.Registration.EmployeeVerification.Command.Create;
using MC.Application.Features.Registration.EmployeeVerification.Command.Delete;
using MC.Application.Features.Registration.EmployeeVerification.Command.Update;
using MC.Application.Features.Registration.EmployeeVerification.Query.DownloadAgencyCertificate;
using MC.Application.Features.Registration.EmployeeVerification.Query.GetAll;
using MC.Application.Features.Registration.EmployeeVerification.Query.GetById;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Registration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeVerificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeVerificationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeVerificationDetailDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByIdEmpVeriQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("get-all-by-user-profile-id/{userProfileId}")]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<EmployeeVerificationDetailDto>>>> GetAllEmployeeVerificationByUserProfile(Guid userProfileId, [FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllEmpVeriQuery(userProfileId, queryParams), cancellationToken);
            return Ok(response);
        }
        [HttpGet("{empVerificationId}/agency-certificate")]
        public async Task<IActionResult> DownloadCertificate(Guid empVerificationId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DownloadAgencyCertificateQuery(empVerificationId), cancellationToken);

            return File(result.FileBytes, result.ContentType, result.FileName);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateEmployeeVerificationCmd request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            //return CreatedAtAction(nameof(Get), new { id = response }, null);
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
        public async Task<ActionResult> Put(UpdateEmployeeVerificationCmd request, CancellationToken cancellationToken)
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
            var command = new DeleteEmployeeVerificationCmd { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}

