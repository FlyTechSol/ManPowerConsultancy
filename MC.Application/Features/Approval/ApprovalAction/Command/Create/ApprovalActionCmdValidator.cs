using FluentValidation;
using MC.Application.Contracts.Persistence.Approval;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.Features.Approval.ApprovalAction.Command.Create
{
    public class ApprovalActionCmdValidator : AbstractValidator<ApprovalActionCmd>
    {
        private readonly IApprovalActionRepository _approvalActionRepository;

        public ApprovalActionCmdValidator(IApprovalActionRepository approvalActionRepository)
        {
            _approvalActionRepository = approvalActionRepository;

            RuleFor(p => p.RequestStageId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ApproverId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Action)
                .IsInEnum().WithMessage("Invalid action.");

            RuleFor(p => p.Comments)
                .NotEmpty().WithMessage("Comments are required when rejecting.")
                .When(p => p.Action == ActionType.Rejected);

            RuleFor(p => p.Comments)
                .MaximumLength(200).WithMessage("Comments cannot exceed 200 characters.");
        }               
    }
}
