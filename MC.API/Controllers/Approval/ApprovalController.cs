using MC.API.Resources;
using MC.Application.Contracts.Identity;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Approval
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalController : ControllerBase
    {
        private readonly IApprovalService _approvalService;
        private readonly IUserContext _userContext;
        public ApprovalController(IApprovalService approvalService, IUserContext userContext)
        {
            _approvalService = approvalService;
            _userContext = userContext;
        }

        [HttpGet("pending")]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<ApprovalStageApproverDto>>>> GetPending([FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var userId = _userContext.UserGuidId;
            if (userId == Guid.Empty)
                return Unauthorized("User not found.");

            var result = await _approvalService.GetPendingApprovalsForUserAsync(userId, queryParams, cancellationToken);
            return Ok(result);
        }

        [HttpPost("{approvalRequestStageId}/approve")]
        public async Task<IActionResult> Approve(Guid approvalRequestStageId, [FromBody] ApprovalActionRequest request)
        {
            var userId = _userContext.UserGuidId;
            if (userId == Guid.Empty)
                return Unauthorized("User not found.");

            await _approvalService.ApproveAsync(approvalRequestStageId, userId, request.Comments, HttpContext.RequestAborted);
            return Ok(ApiResponseMessage<object>.SuccessResponse(null, ResponseMessages.Updated));
        }

        [HttpPost("{approvalRequestStageId}/reject")]
        public async Task<IActionResult> Reject(Guid approvalRequestStageId, [FromBody] ApprovalActionRequest request)
        {
            var userId = _userContext.UserGuidId;
            if (userId == Guid.Empty)
                return Unauthorized("User not found.");

            await _approvalService.RejectAsync(approvalRequestStageId, userId, request.Comments, HttpContext.RequestAborted);
            return Ok(ApiResponseMessage<object>.SuccessResponse(null, ResponseMessages.Updated));
        }

        [HttpPost("{approvalRequestStageId}/delegate/{delegateToUserId}")]
        public async Task<IActionResult> Delegate(Guid approvalRequestStageId, Guid delegateToUserId, [FromBody] ApprovalActionRequest request)
        {
            var userId = _userContext.UserGuidId;
            if (userId == Guid.Empty)
                return Unauthorized("User not found.");

            await _approvalService.DelegateAsync(approvalRequestStageId, userId, delegateToUserId, request.Comments, HttpContext.RequestAborted);
            return Ok(ApiResponseMessage<object>.SuccessResponse(null, ResponseMessages.Updated));
        }
    }
}
