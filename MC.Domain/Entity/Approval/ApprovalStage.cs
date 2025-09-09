using MC.Domain.Base;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Domain.Entity.Approval
{
    public class ApprovalStage : BaseEntity
    {
        public Guid WorkflowId { get; set; }
        public virtual ApprovalWorkflow Workflow { get; set; } = null!;

        public int Order { get; set; } // e.g., 1, 2, 3
        public bool IsFinalStage { get; set; } = false;

        // NEW: parallel/sequential control
        public StageApprovalMode ApprovalMode { get; set; } = StageApprovalMode.Sequential;

        // NEW: approvers (designation or user-based)
        public ICollection<ApprovalStageApprover> Approvers { get; set; } = new List<ApprovalStageApprover>();
    }
}
