using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Country.Command.Update
{
    public class UpdateCountryCmdValidator : AbstractValidator<UpdateCountryCmd>
    {
        private readonly ICountryRepository _countryRepository;

        public UpdateCountryCmdValidator(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.DialCode)
               .MaximumLength(5).WithMessage("{PropertyName} must be fewer than 5 characters");

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters")
                 .MustAsync((command, code, cancellationToken) =>
                    DecodeMustBeUniqueForUpdate(command.Id, code, cancellationToken))
                .WithMessage("{PropertyName} must be unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
        }

        private async Task<bool> DecodeMustBeUniqueForUpdate(Guid id, string decode, CancellationToken cancellationToken)
        {
            var isUnique = await _countryRepository.IsUniqueForUpdate(id, decode, cancellationToken);
            return isUnique;
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var record = await _countryRepository.GetByIdAsync(id, cancellationToken);
            return record != null;
        }
    }
}
