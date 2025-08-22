using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.InsuranceNominee.Command.Create
{
    public class CreateInsNomineeCmdValidator : AbstractValidator<CreateInsNomineeCmd>
    {
        private readonly IInsuranceNomineeRepository _insuranceNomineeRepository;

        public CreateInsNomineeCmdValidator(IInsuranceNomineeRepository insuranceNomineeRepository)
        {
            _insuranceNomineeRepository = insuranceNomineeRepository;

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.NominatedBy)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                 .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.NominatedByFather)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.SoldierNumber)
                .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters");

            RuleFor(p => p.SoldierRank)
                .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters");

            RuleFor(p => p.SoldierUnit)
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.NominatedByCorrespondenceAddress)
            .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(p => p.NominatedByPermanentAddress)
             .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(p => p.NomineeName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.RelationWithNominee)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.NomineeFather)
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.NomineeByPermanentAddress)
            .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(p => p.NomineeByCorrespondenceAddress)
             .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }
    }
}
