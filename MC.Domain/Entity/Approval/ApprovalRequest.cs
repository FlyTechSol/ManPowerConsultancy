using MC.Domain.Base;
using MC.Domain.Entity.Enum.Approval;
using MC.Domain.Entity.Identity;

namespace MC.Domain.Entity.Approval
{
    public class ApprovalRequest : BaseEntity
    {
        public Guid ApprovalWorkflowId { get; set; }
        public virtual ApprovalWorkflow Workflow { get; set; } = null!;

        public Guid RequestedBy { get; set; }
        public virtual ApplicationUser RequestedUser { get; set; } = null!;

        public RequestType RequestType { get; set; }
        public Guid RequestEntityId { get; set; } // e.g., LeaveId, ProfileUpdateId

        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        public ICollection<ApprovalRequestStage> Stages { get; set; } = new List<ApprovalRequestStage>();
    }

}
