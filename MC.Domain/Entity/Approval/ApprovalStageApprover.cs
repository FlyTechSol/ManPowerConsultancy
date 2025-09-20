using MC.Domain.Base;
using MC.Domain.Entity.Identity;
using MC.Domain.Entity.Master;
using MC.Domain.Entity.Organization;

namespace MC.Domain.Entity.Approval
{
    public class ApprovalStageApprover : BaseEntity
    {
        public Guid ApprovalStageId { get; set; }
        public virtual ApprovalStage Stage { get; set; } = null!;

        public Guid? RoleId { get; set; }
        public virtual ApplicationRole? Role { get; set; }

        public Guid? CompanyId { get; set; }
        public virtual Company? Company { get; set; }

        public Guid? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public bool IsMandatory { get; set; } = true; // optional vs required approver
    }
}
