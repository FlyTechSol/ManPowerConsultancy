using MediatR;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Command.Delete
{
    public class DeleteApprovalWorkflowCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
