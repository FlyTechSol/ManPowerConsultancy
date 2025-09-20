using FluentValidation;
using MC.Application.Contracts.Persistence.Approval;

namespace MC.Application.Features.Approval.ApprovalStage.Command.Update;

public class UpdateApprovalStageCmdValidator : AbstractValidator<UpdateApprovalStageCmd>
{
    private readonly IApprovalStageRepository _approvalStageRepository;

    public UpdateApprovalStageCmdValidator(IApprovalStageRepository approvalStageRepository)
    {
        _approvalStageRepository = approvalStageRepository;

        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(RecordMustExist);

        RuleFor(p => p.ApprovalWorkflowId)
                .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(x => x.Order)
             .GreaterThanOrEqualTo(0);

        RuleFor(p => p.ApprovalMode)
            .NotNull().WithMessage("{PropertyName} is required.")   
             .IsInEnum().WithMessage("{PropertyName} is invalid");
    }
    private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
    {
        var record = await _approvalStageRepository.GetByIdAsync(id, cancellationToken);
        return record != null;
    }
}
