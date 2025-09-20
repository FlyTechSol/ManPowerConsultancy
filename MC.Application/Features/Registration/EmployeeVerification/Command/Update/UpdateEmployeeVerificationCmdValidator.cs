using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.EmployeeVerification.Command.Update
{
    public class UpdateEmployeeVerificationCmdValidator : AbstractValidator<UpdateEmployeeVerificationCmd>
    {
        private readonly IEmployeeVerificationRepository _employeeVerificationRepository;

        public UpdateEmployeeVerificationCmdValidator(IEmployeeVerificationRepository employeeVerificationRepository)
        {
            _employeeVerificationRepository = employeeVerificationRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

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

            RuleFor(p => p.Result)
                .IsInEnum().WithMessage("{PropertyName} is invalid");
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _employeeVerificationRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
