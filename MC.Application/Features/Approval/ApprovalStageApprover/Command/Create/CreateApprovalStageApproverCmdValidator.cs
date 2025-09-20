using FluentValidation;
using MC.Application.Contracts.Persistence.Approval;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Command.Create
{
    public class CreateApprovalStageApproverCmdValidator : AbstractValidator<CreateApprovalStageApproverCmd>
    {
        private readonly IApprovalStageApproverRepository _approvalStageApproverRepository;

        public CreateApprovalStageApproverCmdValidator(IApprovalStageApproverRepository approvalStageApproverRepository)
        {
            _approvalStageApproverRepository = approvalStageApproverRepository;

            RuleFor(p => p.ApprovalStageId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => new { p.RoleId, p.UserId })
                .Must(x => x.RoleId.HasValue || x.UserId.HasValue)
                .WithMessage("Either DesignationId or UserId must be provided.");
        }
    }
}
