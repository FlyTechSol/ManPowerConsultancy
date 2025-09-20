using MediatR;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Command.Create
{
    public class CreateApprovalStageApproverCmd : IRequest<Guid>
    {
        public Guid ApprovalStageId { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? UserId { get; set; }
        public bool IsMandatory { get; set; }
    }
}
