using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.Address.Command.Update
{
    public class UpdateAddressCmdValidator : AbstractValidator<UpdateAddressCmd>
    {
        private readonly IAddressRepository _addressRepository;

        public UpdateAddressCmdValidator(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(AddressMustExist);

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.C_AddressLine1)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
            RuleFor(p => p.C_AddressLine2)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
        }

        private async Task<bool> AddressMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _addressRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
