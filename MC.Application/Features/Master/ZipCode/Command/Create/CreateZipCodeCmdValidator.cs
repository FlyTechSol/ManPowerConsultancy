using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.ZipCode.Command.Create
{
    public class CreateZipCodeCmdValidator : AbstractValidator<CreateZipCodeCmd>
    {
        private readonly IZipCodeRepository _zipCodeRepository;
        public CreateZipCodeCmdValidator(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;

            RuleFor(p => p.Zipcode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters")
                .MustAsync(CodeMustBeUnique).WithMessage("Code must be unique");

            RuleFor(p => p.City)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.State)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.District)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.Country)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
        }

        private Task<bool> CodeMustBeUnique(string code, CancellationToken token)
        {
            return _zipCodeRepository.IsUnique(code, token);
        }
    }
}
