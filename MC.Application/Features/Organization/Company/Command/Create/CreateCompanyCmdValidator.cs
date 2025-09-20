using FluentValidation;
using MC.Application.Contracts.Persistence.Organization;

namespace MC.Application.Features.Organization.Company.Command.Create
{
    public class CreateCompanyCmdValidator : AbstractValidator<CreateCompanyCmd>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCmdValidator(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

            RuleFor(p => p.CompanyName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

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

            RuleFor(p => p.RegistrationPrefix)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");

            RuleFor(p => p.LastRegistrationId)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be zero or positive");

            RuleFor(q => q)
                .MustAsync(RecordMustUnique)
                .WithMessage("company record already exists");
        }

        private Task<bool> RecordMustUnique(CreateCompanyCmd command, CancellationToken token)
        {
            return _companyRepository.IsUnique(command.CompanyName, token);
        }
    }
}
