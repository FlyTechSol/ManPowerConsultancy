using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Query.GetAll
{
    public class GetAllApprovalWorkflowsQuery : IRequest<ApiResponse<PaginatedResponse<ApprovalWorkflowDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllApprovalWorkflowsQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
