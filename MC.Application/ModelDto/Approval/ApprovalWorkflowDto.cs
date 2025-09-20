using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.ModelDto.Approval
{
    public class ApprovalWorkflowDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string WorkflowTypeName { get; set; } = string.Empty;
        public WorkflowType WorkflowType { get; set; }
    }
}
