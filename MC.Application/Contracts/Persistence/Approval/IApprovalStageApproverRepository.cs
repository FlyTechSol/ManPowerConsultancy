using MC.Domain.Entity.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalStageApproverRepository : IGenericRepository<ApprovalStageApprover>
    {
        Task<IList<ApprovalStageApprover>> GetApproversByStageIdAsync(Guid stageId, CancellationToken cancellationToken);
    }

}
