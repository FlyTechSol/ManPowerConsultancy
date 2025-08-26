using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.Communication.Command.Create
{
    public class CreateCommunicationCmdValidator : AbstractValidator<CreateCommunicationCmd>
    {
        private readonly ICommunicationRepository _communicationRepository;

        public CreateCommunicationCmdValidator(ICommunicationRepository communicationRepository)
        {
            _communicationRepository = communicationRepository;

            RuleFor(p => p.UserProfileId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.PersonalMobileNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(15).WithMessage("{PropertyName} must be fewer than 15 characters");

            RuleFor(p => p.OfficialMobileNumber)
                .MaximumLength(15).WithMessage("{PropertyName} must be fewer than 15 characters");

            RuleFor(p => p.EmergencyContactNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(15).WithMessage("{PropertyName} must be fewer than 15 characters");

            RuleFor(p => p.LandlineNumber1)
                .MaximumLength(15).WithMessage("{PropertyName} must be fewer than 15 characters");

            RuleFor(p => p.LandlineNumber2)
                .MaximumLength(15).WithMessage("{PropertyName} must be fewer than 15 characters");

            RuleFor(p => p.PersonalEmail)
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.OfficialEmail)
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");
        }
    }
}
