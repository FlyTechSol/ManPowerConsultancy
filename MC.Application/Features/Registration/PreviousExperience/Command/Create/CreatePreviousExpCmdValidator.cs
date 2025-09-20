using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.PreviousExperience.Command.Create
{
    public class CreatePreviousExpCmdValidator : AbstractValidator<CreatePreviousExpCmd>
    {
        private readonly IPreviousExperienceRepository _previousExperienceRepository;

        public CreatePreviousExpCmdValidator(IPreviousExperienceRepository previousExperienceRepository)
        {
            _previousExperienceRepository = previousExperienceRepository;

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.CompanyWorked)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.Place)
                .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.Duration)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.ReasonForLeft)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

        }
    }
}
