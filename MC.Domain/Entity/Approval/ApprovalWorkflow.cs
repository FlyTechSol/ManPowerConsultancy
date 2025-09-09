using MC.Domain.Base;
using MC.Domain.Entity.Enum.Approval;
using MC.Domain.Entity.Organization;

namespace MC.Domain.Entity.Approval
{
    public class ApprovalWorkflow : BaseEntity
    {
        public WorkflowType WorkflowType { get; set; } 
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;

        public ICollection<ApprovalStage> Stages { get; set; } = new List<ApprovalStage>();
        public ICollection<ApprovalRequest> Requests { get; set; } = new List<ApprovalRequest>();
    }
}
