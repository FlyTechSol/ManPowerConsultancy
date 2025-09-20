using MC.Domain.Entity.Enum.Approval;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Command.Update
{
    public class UpdateApprovalWorkflowCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public WorkflowType WorkflowType { get; set; }
        public Guid CompanyId { get; set; }
    }
}
