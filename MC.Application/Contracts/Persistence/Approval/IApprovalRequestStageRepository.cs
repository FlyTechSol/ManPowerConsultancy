using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalRequestStageRepository : IGenericRepository<ApprovalRequestStage>
    {
        Task AddApprovalRequestStagesAsync(ApprovalRequest approvalRequest, IEnumerable<ApprovalStage> stages, CancellationToken cancellationToken);
        Task<IList<ApprovalRequestStage>> GetStagesByRequestIdAsync(Guid approvalRequestId, CancellationToken cancellationToken);
        Task<ApprovalRequestStage?> GetCurrentStageAsync(Guid approvalRequestId, CancellationToken cancellationToken);
        Task<ApprovalRequestStage?> GetNextStageAsync(Guid approvalRequestId, int currentOrder, CancellationToken cancellationToken);
        Task UpdateStageStatusAsync(Guid approvalRequestStageId, StageStatus status, CancellationToken cancellationToken);
        Task<IList<ApprovalRequestStage>> GetPendingStagesForApproverAsync(Guid approverId, CancellationToken cancellationToken);
        Task<PaginatedResponse<ApprovalRequestStageDto>> GetPendingStagesForApproverAsync(Guid approverId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<IList<ApprovalRequestStage>> GetPreviousStagesAsync(Guid approvalRequestId, int currentOrder, CancellationToken cancellationToken);
    }
}
