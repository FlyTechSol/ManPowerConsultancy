using FluentValidation;
using MC.Application.Contracts.Persistence.Approval;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Command.Update
{
    public class UpdateApprovalStageApproverCmdValidator : AbstractValidator<UpdateApprovalStageApproverCmd>
    {
        private readonly IApprovalStageApproverRepository _approvalStageApproverRepository;

        public UpdateApprovalStageApproverCmdValidator(IApprovalStageApproverRepository approvalStageApproverRepository)
        {
            _approvalStageApproverRepository = approvalStageApproverRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.ApprovalStageId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => new { p.RoleId, p.UserId })
                .Must(x => x.RoleId.HasValue || x.UserId.HasValue)
                .WithMessage("Either DesignationId or UserId must be provided.");
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var record = await _approvalStageApproverRepository.GetByIdAsync(id, cancellationToken);
            return record != null;
        }
    }
}
