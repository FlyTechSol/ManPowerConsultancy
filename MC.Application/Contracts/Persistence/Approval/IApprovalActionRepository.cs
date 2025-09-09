using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalActionRepository : IGenericRepository<ApprovalAction>
    {
        Task<ApprovalAction> AddActionAsync(Guid requestStageId, Guid approverId, ActionType action, string? comments, CancellationToken cancellationToken);
        Task<IList<ApprovalAction>> GetActionsByRequestStageIdAsync(Guid requestStageId, CancellationToken cancellationToken);
    }
}
