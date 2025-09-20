using MC.Domain.Entity.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalEligibilityService
    {
        Task<bool> CanUserApproveStageAsync(Guid userId, ApprovalStage stage);
    }
}
