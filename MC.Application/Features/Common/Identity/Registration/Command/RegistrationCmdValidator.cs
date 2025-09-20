using FluentValidation;
using MC.Application.Contracts.Identity;
using MC.Application.Features.Registration.BankAccount.Command.Create;

namespace MC.Application.Features.Common.Identity.Registration.Command
{
    public class RegistrationCmdValidator : AbstractValidator<RegistrationCmd>
    {
        private readonly IAuthService _authenticationService;

        public RegistrationCmdValidator(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Mobile number is required.");

            RuleFor(x => x.Email)
             .NotEmpty().WithMessage("Email is required.")
             .EmailAddress().WithMessage("Invalid email format.")
             .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.")
             .MustAsync(EmailMustBeUnique).WithMessage("Email already exists.");

            RuleFor(x => x.Mobile)
                .NotEmpty().WithMessage("Mobile number is required.")
                .MaximumLength(15).WithMessage("Mobile number cannot exceed 15 characters.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.MiddleName)
                .MaximumLength(50).WithMessage("Middle name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Length(5, 15).WithMessage("Username must be between 5 and 15 characters.")
                .MustAsync(UserNameMustBeUnique).WithMessage("Username already exists.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .MaximumLength(50).WithMessage("Password cannot exceed 50 characters."); // optional

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("RoleId is required.");
        }

        private Task<bool> EmailMustBeUnique(string email, CancellationToken cancellationToken)
        {
            return _authenticationService.IsEmailUnique(email, cancellationToken);
        }

        private Task<bool> UserNameMustBeUnique(string userName, CancellationToken cancellationToken)
        {
            return _authenticationService.IsUserNameUnique(userName, cancellationToken);
        }
    }
}
