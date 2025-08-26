using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.BankAccount.Command.Create
{
    public class CreateBankAccountCmdValidator : AbstractValidator<CreateBankAccountCmd>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public CreateBankAccountCmdValidator(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;

            RuleFor(p => p.IFSCCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(15).WithMessage("{PropertyName} must be fewer than 15 characters");

            RuleFor(p => p.BankName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.AccountNo)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters");

            RuleFor(q => q)
                .MustAsync(BankDetailUnique)
                .WithMessage("Bank detail already exists");
        }

        private Task<bool> BankDetailUnique(CreateBankAccountCmd command, CancellationToken cancellationToken)
        {
            return _bankAccountRepository.IsUnique(command.IFSCCode, command.AccountNo, cancellationToken);
        }
    }
}
