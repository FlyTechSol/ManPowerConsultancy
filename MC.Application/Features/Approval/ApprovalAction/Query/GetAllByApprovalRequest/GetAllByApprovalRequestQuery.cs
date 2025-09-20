using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalAction.Query.GetAllByApprovalRequest
{
    public class GetAllByApprovalRequestQuery : IRequest<ApiResponse<PaginatedResponse<ApprovalActionDto>>>
    {
        public QueryParams QueryParams { get; set; }
        public Guid ApprovalRequestId { get; set; }
        public GetAllByApprovalRequestQuery(Guid approvalRequestId, QueryParams queryParams)
        {
            ApprovalRequestId = approvalRequestId;
            QueryParams = queryParams;
        }
    }
}
