using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Features.Approval.ApprovalAction.Query.GetAllByApprovalRequestStage
{
    public class GetAllByApprovalRequestStageQuery : IRequest<ApiResponse<PaginatedResponse<ApprovalActionDto>>>
    {
        public QueryParams QueryParams { get; set; }
        public Guid ApprovalRequestStageId { get; set; }
        public GetAllByApprovalRequestStageQuery(Guid approvalRequestStageId, QueryParams queryParams)
        {
            ApprovalRequestStageId = approvalRequestStageId;
            QueryParams = queryParams;
        }
    }
}
