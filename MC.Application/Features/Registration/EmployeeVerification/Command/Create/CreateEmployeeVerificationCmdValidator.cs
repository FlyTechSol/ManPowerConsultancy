using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.EmployeeVerification.Command.Create
{
    public class CreateEmployeeVerificationCmdValidator : AbstractValidator<CreateEmployeeVerificationCmd>
    {
        private readonly IEmployeeVerificationRepository _employeeVerificationRepository;

        public CreateEmployeeVerificationCmdValidator(IEmployeeVerificationRepository employeeVerificationRepository)
        {
            _employeeVerificationRepository = employeeVerificationRepository;

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.VerificationType)
                .NotNull().WithMessage("{PropertyName} is required.")
                 .IsInEnum().WithMessage("{PropertyName} is invalid");

            RuleFor(p => p.AgencyName)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.InitiatedDate)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Status)
                .NotNull().WithMessage("{PropertyName} is required.")
                 .IsInEnum().WithMessage("{PropertyName} is invalid");
        }
    }
}
