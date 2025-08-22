using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.ExArmy.Command.Update
{
    public class UpdateExArmyCmdValidator : AbstractValidator<UpdateExArmyCmd>
    {
        private readonly IExArmyRepository _exArmyRepository;

        public UpdateExArmyCmdValidator(IExArmyRepository exArmyRepository)
        {
            _exArmyRepository = exArmyRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ServiceNumber)
                .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters");

            RuleFor(p => p.Rank)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                 .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.Unit)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.TotalService)
                .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters");

            RuleFor(p => p.ReasonForDischarge)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(p => p.DischargeCertificateUrl)
                .MaximumLength(256).WithMessage("{PropertyName} must be fewer than 256 characters");
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _exArmyRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
