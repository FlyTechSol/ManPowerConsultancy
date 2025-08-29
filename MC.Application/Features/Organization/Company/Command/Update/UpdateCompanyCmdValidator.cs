using FluentValidation;
using MC.Application.Contracts.Persistence.Organization;

namespace MC.Application.Features.Organization.Company.Command.Update
{
    public class UpdateCompanyCmdValidator : AbstractValidator<UpdateCompanyCmd>
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyCmdValidator(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.CompanyName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters")
                .MustAsync((command, companyName, cancellationToken) =>
                    DecodeMustBeUniqueForUpdate(command.Id, companyName, cancellationToken))
                .WithMessage("{PropertyName} must be unique.");

            RuleFor(p => p.LegalName)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.RegistrationNumber)
               .MaximumLength(25).WithMessage("{PropertyName} must be fewer than 25 characters");

            RuleFor(p => p.CompanyPan)
              .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");

            RuleFor(p => p.Email)
               .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.Phone)
              .MaximumLength(15).WithMessage("{PropertyName} must be fewer than 15 characters");

            RuleFor(p => p.Website)
               .MaximumLength(256).WithMessage("{PropertyName} must be fewer than 256 characters");

            RuleFor(p => p.AddressLine1)
              .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.AddressLine2)
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.City)
              .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.State)
              .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.Country)
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.ZipCode)
              .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");
        }

        private async Task<bool> DecodeMustBeUniqueForUpdate(Guid id, string companyName, CancellationToken cancellationToken)
        {
            var isUnique = await _companyRepository.IsUniqueForUpdate(id, companyName, cancellationToken);
            return isUnique;
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var record = await _companyRepository.GetByIdAsync(id, cancellationToken);
            return record != null;
        }
    }
}
