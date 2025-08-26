using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.Resignation.Command.Create
{
    public class CreateResignationCmdValidator : AbstractValidator<CreateResignationCmd>
    {
        private readonly IResignationRepository _resignationRepository;

        public CreateResignationCmdValidator(IResignationRepository resignationRepository)
        {
            _resignationRepository = resignationRepository;

            RuleFor(p => p.UserProfileId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Reason)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }
    }
}
