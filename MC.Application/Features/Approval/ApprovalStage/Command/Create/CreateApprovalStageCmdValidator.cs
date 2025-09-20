using FluentValidation;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Approval.ApprovalStage.Command.Create
{
    public class CreateApprovalStageCmdValidator : AbstractValidator<CreateApprovalStageCmd>
    {
        private readonly IApprovalStageRepository _approvalStageRepository;

        public CreateApprovalStageCmdValidator(IApprovalStageRepository approvalStageRepository)
        {
            _approvalStageRepository = approvalStageRepository;

            RuleFor(p => p.ApprovalWorkflowId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Order)
                 .GreaterThanOrEqualTo(0);

            RuleFor(p => p.ApprovalMode)
                .NotNull().WithMessage("{PropertyName} is required.")
                 .IsInEnum().WithMessage("{PropertyName} is invalid");
        }
    }
}
