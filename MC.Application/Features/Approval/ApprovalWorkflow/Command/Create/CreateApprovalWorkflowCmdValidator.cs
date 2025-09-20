using FluentValidation;
using MC.Application.Contracts.Persistence.Approval;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Command.Create
{
    public class CreateApprovalWorkflowCmdValidator : AbstractValidator<CreateApprovalWorkflowCmd>
    {
        private readonly IApprovalWorkflowRepository _approvalWorkflowRepository;

        public CreateApprovalWorkflowCmdValidator(IApprovalWorkflowRepository approvalWorkflowRepository)
        {
            _approvalWorkflowRepository = approvalWorkflowRepository;

            RuleFor(p => p.CompanyId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => new { p.CompanyId, p.WorkflowType })
                .MustAsync(BeUniqueWorkflowForCompany)
                .WithMessage("An approval workflow of this type already exists for the company.");

            RuleFor(p => p.WorkflowType)
                .NotNull().WithMessage("{PropertyName} is required.")
                .IsInEnum().WithMessage("{PropertyName} is invalid");
        }

        private async Task<bool> BeUniqueWorkflowForCompany(dynamic x, CancellationToken token)
        {
            return await _approvalWorkflowRepository
                .IsWorkflowUniqueAsync(x.CompanyId, x.WorkflowType, token);
        }
    }
}
