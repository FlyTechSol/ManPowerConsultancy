using MC.Domain.Entity.Enum.Approval;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalAction.Command.Create
{
    public class ApprovalActionCmd : IRequest<Guid>
    {
        public Guid RequestStageId { get; set; }
        public Guid ApproverId { get; set; }
        public ActionType Action { get; set; }
        public string? Comments { get; set; }
    }
}
