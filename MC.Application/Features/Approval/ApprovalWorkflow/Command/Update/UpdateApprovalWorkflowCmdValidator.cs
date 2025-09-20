using FluentValidation;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Command.Update
{
    public class UpdateApprovalWorkflowCmdValidator : AbstractValidator<UpdateApprovalWorkflowCmd>
    {
        private readonly IApprovalWorkflowRepository _approvalWorkflowRepository;

        public UpdateApprovalWorkflowCmdValidator(IApprovalWorkflowRepository approvalWorkflowRepository)
        {
            _approvalWorkflowRepository = approvalWorkflowRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.CompanyId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.WorkflowType)
                .NotNull().WithMessage("{PropertyName} is required.")
               .IsInEnum().WithMessage("{PropertyName} is invalid");

            RuleFor(p => new { p.Id, p.CompanyId, p.WorkflowType })
               .MustAsync(BeUniqueWorkflowForCompany)
               .WithMessage("An approval workflow of this type already exists for the company.");
        }
        private async Task<bool> BeUniqueWorkflowForCompany(dynamic x, CancellationToken token)
        {
            return await _approvalWorkflowRepository
                .IsWorkflowUniqueForUpdateAsync(x.Id, x.CompanyId, x.WorkflowType, token);
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var record = await _approvalWorkflowRepository.GetByIdAsync(id, cancellationToken);
            return record != null;
        }
    }
}
