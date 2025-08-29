using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Branch.Command.Create
{
    public class CreateBranchCmdValidator : AbstractValidator<CreateBranchCmd>
    {
        private readonly IBranchRepository _branchRepository;

        public CreateBranchCmdValidator(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(q => q)
                .MustAsync(CodeMustUnique)
                .WithMessage("Branch record already exists");
        }

        private Task<bool> CodeMustUnique(CreateBranchCmd command, CancellationToken token)
        {
            return _branchRepository.IsUnique(command.Code, token);
        }
    }
}
