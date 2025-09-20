using MC.Domain.Entity.Enum.Approval;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStage.Command.Update
{
    public class UpdateApprovalStageCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid ApprovalWorkflowId { get; set; }
        public int Order { get; set; }
        public bool IsFinalStage { get; set; }
        public StageApprovalMode ApprovalMode { get; set; }
    }
}
