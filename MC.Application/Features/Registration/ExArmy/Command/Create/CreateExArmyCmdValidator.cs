using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.ExArmy.Command.Create
{
    public class CreateExArmyCmdValidator : AbstractValidator<CreateExArmyCmd>
    {
        private readonly IExArmyRepository _exArmyRepository;

        public CreateExArmyCmdValidator(IExArmyRepository exArmyRepository)
        {
            _exArmyRepository = exArmyRepository;

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

            //RuleFor(p => p.DischargeCertificateUrl)
            //    .MaximumLength(256).WithMessage("{PropertyName} must be fewer than 256 characters");
        }
    }
}
