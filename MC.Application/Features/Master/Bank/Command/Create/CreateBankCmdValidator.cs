using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Bank.Command.Create
{
    public class CreateBankCmdValidator : AbstractValidator<CreateBankCmd>
    {
        private readonly IBankRepository _bankRepository;

        public CreateBankCmdValidator(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(q => q)
                .MustAsync(CodeMustUnique)
                .WithMessage("Bank record already exists");
        }

        private Task<bool> CodeMustUnique(CreateBankCmd command, CancellationToken token)
        {
            return _bankRepository.IsUnique(command.Code, token);
        }
    }
}
