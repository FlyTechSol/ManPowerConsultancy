using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.SecurityDeposit.Command.Update
{
   public class UpdateSecurityDepositCmdValidator : AbstractValidator<UpdateSecurityDepositCmd>
    {
        private readonly ISecurityDepositRepository _securityDepositRepository;

        public UpdateSecurityDepositCmdValidator(ISecurityDepositRepository securityDepositRepository)
        {
            _securityDepositRepository = securityDepositRepository;

            RuleFor(p => p.Id)
                 .NotNull()
                 .MustAsync(RecordMustExist);

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
        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _securityDepositRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
