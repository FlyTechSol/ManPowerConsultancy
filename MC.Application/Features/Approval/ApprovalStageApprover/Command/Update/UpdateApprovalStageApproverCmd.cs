using MediatR;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Command.Update
{
    public class UpdateApprovalStageApproverCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid ApprovalStageId { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? UserId { get; set; }
        public bool IsMandatory { get; set; }
    }
}
