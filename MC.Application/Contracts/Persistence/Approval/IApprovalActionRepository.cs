using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalActionRepository : IGenericRepository<ApprovalAction>
    {
        Task<ApprovalAction> AddActionAsync(Guid approvalRequestStageId, Guid approverId, ActionType action, string? comments, CancellationToken cancellationToken);
        Task<PaginatedResponse<ApprovalActionDto>?> GetActionsByRequestStageIdAsync(Guid approvalRequestStageId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<PaginatedResponse<ApprovalActionDto>?> GetActionsByRequestIdAsync(Guid approvalRequestId, QueryParams queryParams, CancellationToken cancellationToken);
    }
}
