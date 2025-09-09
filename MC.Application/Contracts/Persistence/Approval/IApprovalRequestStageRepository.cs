using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalRequestStageRepository : IGenericRepository<ApprovalRequestStage>
    {
        Task<IList<ApprovalRequestStage>> GetStagesByRequestIdAsync(Guid requestId, CancellationToken cancellationToken);
        Task<ApprovalRequestStage?> GetCurrentStageAsync(Guid requestId, CancellationToken cancellationToken);
        Task UpdateStageStatusAsync(Guid requestStageId, StageStatus status, CancellationToken cancellationToken);
    }
}
