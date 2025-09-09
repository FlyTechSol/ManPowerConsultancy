using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.BankAccount.Command.Update
{
    public class UpdateBankAccountCmdValidator : AbstractValidator<UpdateBankAccountCmd>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public UpdateBankAccountCmdValidator(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
            RuleFor(p => p.Id)
                 .NotNull()
                 .MustAsync(BankDetailMustExist);

            RuleFor(p => p.IFSCCode)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                 .MaximumLength(15).WithMessage("{PropertyName} must be fewer than 15 characters")
                 .MustAsync((command, ifscCode, cancellationToken) =>
                     MustBeUniqueForUpdate(command.Id, ifscCode, command.AccountNo, cancellationToken))
                 .WithMessage("{PropertyName} must be unique.");

            RuleFor(p => p.AccountNo)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters")
                .MustAsync((command, accountNo, cancellationToken) =>
                    MustBeUniqueForUpdate(command.Id, command.IFSCCode, accountNo, cancellationToken))
                .WithMessage("{PropertyName} must be unique.");

            RuleFor(p => p.BankId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            //RuleFor(p => p.AccountNo)
            //   .NotEmpty().WithMessage("{PropertyName} is required")
            //   .NotNull()
            //   .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters")
            //   .MustAsync((command, value, cancellationToken) => MustBeUniqueForUpdate(command.Id, value, command.IFSCCode, cancellationToken))
            //   .WithMessage("{PropertyName} must be unique.");
        }
        private async Task<bool> MustBeUniqueForUpdate(Guid id, string accountNo, string ifscCode, CancellationToken cancellationToken)
        {
            // Ensure the combination of BankName and IFSCCode is unique
            var isUnique = await _bankAccountRepository.IsUniqueForUpdate(id, ifscCode, accountNo, cancellationToken);
            return isUnique;
        }
        private async Task<bool> BankDetailMustExist(Guid id, CancellationToken cancellationToken)
        {
            var bankDetail = await _bankAccountRepository.GetByIdAsync(id, cancellationToken);
            return bankDetail != null;
        }
    }
}
