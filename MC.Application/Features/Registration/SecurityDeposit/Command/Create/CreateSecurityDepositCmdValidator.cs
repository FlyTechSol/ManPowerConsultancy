using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.SecurityDeposit.Command.Create
{
    public class CreateSecurityDepositCmdValidator : AbstractValidator<CreateSecurityDepositCmd>
    {
        private readonly ISecurityDepositRepository _securityDepositRepository;

        public CreateSecurityDepositCmdValidator(ISecurityDepositRepository securityDepositRepository)
        {
            _securityDepositRepository = securityDepositRepository;

            RuleFor(p => p.UserProfileId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ReciptNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(15).WithMessage("{PropertyName} must be fewer than 15 characters");

            RuleFor(p => p.Remark)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }
    }
}
