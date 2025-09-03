using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.UserProfile.Command.Create
{
    public class CreateUserProfileCmdValidator : AbstractValidator<CreateUserProfileCmd>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public CreateUserProfileCmdValidator(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;

            RuleFor(p => p.CompanyId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ClientMasterId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ClientUnitId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.MiddleName)
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.LastName)
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.DateOfJoining)
                .NotEmpty().WithMessage("Date of Joining is required")
                .Must(date => date <= DateTime.Today)
                .WithMessage("Date of Joining cannot be in the future");

            // Unique field validations
            RuleFor(p => p.AadhaarNumber)
                .MustAsync(IsAadhaarUnique)
                .WithMessage("Aadhaar number already exists");

            RuleFor(p => p.PanNo)
             .MustAsync((cmd, pan, ct) => IsPanUnique(pan!, ct))
             .When(p => !string.IsNullOrWhiteSpace(p.PanNo))
             .WithMessage("PAN number already exists");

            RuleFor(p => p.UanNumber)
                .MustAsync((cmd, uan, ct) => IsUanUnique(uan!, ct))
                .When(p => !string.IsNullOrWhiteSpace(p.UanNumber))
                .WithMessage("UAN number already exists");

            RuleFor(p => p.EsicNumber)
                .MustAsync((cmd, esic, ct) => IsEsicUnique(esic!, ct))
                .When(p => !string.IsNullOrWhiteSpace(p.EsicNumber))
                .WithMessage("ESIC number already exists");
        }

        private Task<bool> IsAadhaarUnique(string aadhaar, CancellationToken token)
        => _userProfileRepository.IsAadhaarUnique(aadhaar, token);

        private Task<bool> IsPanUnique(string pan, CancellationToken token)
            => _userProfileRepository.IsPanUnique(pan, token);

        private Task<bool> IsUanUnique(string uan, CancellationToken token)
            => _userProfileRepository.IsUanNumberUnique(uan, token);

        private Task<bool> IsEsicUnique(string esic, CancellationToken token)
            => _userProfileRepository.IsEsicUnique(esic, token);
    }
}
