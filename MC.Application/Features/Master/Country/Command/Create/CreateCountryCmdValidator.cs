using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Country.Command.Create
{
    public class CreateCountryCmdValidator : AbstractValidator<CreateCountryCmd>
    {
        private readonly ICountryRepository _countryRepository;

        public CreateCountryCmdValidator(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;

            RuleFor(p => p.DialCode)
                .MaximumLength(5).WithMessage("{PropertyName} must be fewer than 5 characters");

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters")
                .MustAsync(CodeMustBeUnique).WithMessage("Code must be unique");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            //RuleFor(q => q)
            //    .MustAsync(CodeMustUnique)
            //    .WithMessage("Country already exists");
        }

        private Task<bool> CodeMustBeUnique(string code, CancellationToken token)
        {
            return _countryRepository.IsUnique(code, token);
        }
    }
}
