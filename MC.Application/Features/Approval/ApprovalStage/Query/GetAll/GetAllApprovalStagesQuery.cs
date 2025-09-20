using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStage.Query.GetAll
{
    public class GetAllApprovalStagesQuery : IRequest<ApiResponse<PaginatedResponse<ApprovalStagesDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllApprovalStagesQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
