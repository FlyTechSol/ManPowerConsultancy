using MediatR;

namespace MC.Application.Features.Approval.ApprovalStage.Command.Delete
{
    public class DeleteApprovalStageCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
