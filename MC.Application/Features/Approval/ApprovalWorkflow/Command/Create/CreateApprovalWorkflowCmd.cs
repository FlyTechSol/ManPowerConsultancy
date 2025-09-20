using MC.Domain.Entity.Enum.Approval;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Command.Create
{
    public class CreateApprovalWorkflowCmd : IRequest<Guid>
    {
        public WorkflowType WorkflowType { get; set; }
        public Guid CompanyId { get; set; }
    }
}
