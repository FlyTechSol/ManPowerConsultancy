using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.ModelDto.Approval
{
    public class ApprovalStagesDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid ApprovalWorkflowId { get; set; }
        public string ApprovalWorkflowName { get; set; } = string.Empty;
        public WorkflowType ApprovalWorkflowType { get; set; }
        public int Order { get; set; }
        public bool IsFinalStage { get; set; }
        public StageApprovalMode ApprovalMode { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string DropDownValue { get; set; } = string.Empty;
    }
}
