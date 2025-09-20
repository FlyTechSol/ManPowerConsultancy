using MC.Domain.Entity.Enum.Approval;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStage.Command.Create
{
    public class CreateApprovalStageCmd : IRequest<Guid>
    {
        public Guid ApprovalWorkflowId { get; set; }
        public int Order { get; set; }
        public bool IsFinalStage { get; set; } = false;
        public StageApprovalMode ApprovalMode { get; set; } = StageApprovalMode.Sequential;
    }
}
