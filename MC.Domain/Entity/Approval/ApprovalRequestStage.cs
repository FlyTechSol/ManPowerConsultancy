using MC.Domain.Base;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Domain.Entity.Approval
{
    public class ApprovalRequestStage : BaseEntity
    {
        public Guid RequestId { get; set; }
        public virtual ApprovalRequest Request { get; set; } = null!;

        public Guid StageId { get; set; }
        public virtual ApprovalStage Stage { get; set; } = null!;

        public StageStatus Status { get; set; } = StageStatus.Pending;

        public ICollection<ApprovalAction> Actions { get; set; } = new List<ApprovalAction>();
    }
}
