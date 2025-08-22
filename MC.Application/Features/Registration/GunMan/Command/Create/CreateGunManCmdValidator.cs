using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.GunMan.Command.Create
{
    public class CreateGunManCmdValidator : AbstractValidator<CreateGunManCmd>
    {
        private readonly IGunManRepository _gunManRepository;

        public CreateGunManCmdValidator(IGunManRepository gunManRepository)
        {
            _gunManRepository = gunManRepository;

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.GunLicenceName)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.GunLicenseNumber)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                 .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.WeaponNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.MakeOfCompany)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.GunLicenseIssuedBy)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.GunLicenseRemarks)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(p => p.Jurisdiction)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.LicenceAddress)
               .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }
    }
}
