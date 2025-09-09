using MC.Domain.Entity.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalStageRepository : IGenericRepository<ApprovalStage>
    {
        Task<IList<ApprovalStage>> GetWorkflowStagesAsync(Guid workflowId, CancellationToken cancellationToken);
    }
}
