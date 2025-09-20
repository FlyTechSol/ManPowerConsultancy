using MediatR;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Command.Delete
{
    public class DeleteApprovalStageApproverCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
