using MC.Domain.Base;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Domain.Entity.Approval
{
    public class ApprovalRequestStage : BaseEntity
    {
        public Guid ApprovalRequestId { get; set; }
        public virtual ApprovalRequest Request { get; set; } = null!;

        public Guid ApprovalStageId { get; set; }
        public virtual ApprovalStage Stage { get; set; } = null!;

        public StageStatus Status { get; set; } = StageStatus.Pending;

        public ICollection<ApprovalAction> Actions { get; set; } = new List<ApprovalAction>();
    }
}
