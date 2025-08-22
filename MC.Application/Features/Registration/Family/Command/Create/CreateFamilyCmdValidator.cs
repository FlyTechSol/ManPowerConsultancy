using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.Family.Command.Create
{
    public class CreateFamilyCmdValidator : AbstractValidator<CreateFamilyCmd>
    {
        private readonly IFamilyRepository _familyRepository;

        public CreateFamilyCmdValidator(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.RelationTo)
                .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.Address)
                .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters");
        }
    }
}
