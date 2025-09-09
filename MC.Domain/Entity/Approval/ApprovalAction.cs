using MC.Domain.Base;
using MC.Domain.Entity.Enum.Approval;
using MC.Domain.Entity.Identity;

namespace MC.Domain.Entity.Approval
{
    public class ApprovalAction : BaseEntity
    {
        public Guid RequestStageId { get; set; }
        public virtual ApprovalRequestStage RequestStage { get; set; } = null!;

        public Guid ApproverId { get; set; }
        public virtual ApplicationUser Approver { get; set; } = null!;

        public ActionType Action { get; set; } // Approved, Rejected, Delegated
        public string? Comments { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;
    }

}
