using MC.Domain.Base;
using MC.Domain.Entity.Identity;
using MC.Domain.Entity.Master;

namespace MC.Domain.Entity.Approval
{
    public class ApprovalStageApprover : BaseEntity
    {
        public Guid StageId { get; set; }
        public virtual ApprovalStage Stage { get; set; } = null!;

        public Guid? DesignationId { get; set; }
        public virtual Designation? Designation { get; set; }

        public Guid? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public bool IsMandatory { get; set; } = true; // optional vs required approver
    }
}
