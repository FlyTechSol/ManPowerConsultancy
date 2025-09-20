using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalService
    {
        Task<PaginatedResponse<PendingApprovalStageDto>> GetPendingApprovalsForUserAsync(Guid userId, QueryParams queryParams, CancellationToken cancellationToken);
        Task ApproveAsync(Guid approvalRequestStageId, Guid approverId, string? comments, CancellationToken cancellationToken);
        Task RejectAsync(Guid approvalRequestStageId, Guid approverId, string? comments, CancellationToken cancellationToken);
        Task DelegateAsync(Guid approvalRequestStageId, Guid approverId, Guid delegateToUserId, string? comments, CancellationToken cancellationToken);
    }
}
