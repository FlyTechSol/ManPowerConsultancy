using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.PoliceVerification.Command.Create
{
    public class CreatePoliceVeriCmdValidator : AbstractValidator<CreatePoliceVeriCmd>
    {
        private readonly IPoliceVerificationRepository _policeVerificationRepository;

        public CreatePoliceVeriCmdValidator(IPoliceVerificationRepository policeVerificationRepository)
        {
            _policeVerificationRepository = policeVerificationRepository;

            RuleFor(p => p.UserProfileId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.PoliceStationName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.VerificationRemarks)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }
    }
}
