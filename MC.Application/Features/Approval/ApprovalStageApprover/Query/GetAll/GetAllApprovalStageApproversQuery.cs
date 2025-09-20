using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Query.GetAll
{
    public class GetAllApprovalStageApproversQuery : IRequest<ApiResponse<PaginatedResponse<ApprovalStageApproverDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllApprovalStageApproversQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
