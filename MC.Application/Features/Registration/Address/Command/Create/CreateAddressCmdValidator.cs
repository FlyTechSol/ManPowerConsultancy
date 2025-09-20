using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.Address.Command.Create
{
    public class CreateAddressCmdValidator : AbstractValidator<CreateAddressCmd>
    {
        private readonly IAddressRepository _studentAddressRepository;

        public CreateAddressCmdValidator(IAddressRepository studentAddressRepository)
        {
            _studentAddressRepository = studentAddressRepository;

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");
               
            RuleFor(p => p.AddressLine1)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.AddressLine2)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                 .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.AddressType)
                .NotNull().WithMessage("{PropertyName} is required.")
                .IsInEnum().WithMessage("A valid address type must be selected.");
        }
    }
}
