using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.Insurance.Command.Update
{
    public class UpdateInsuranceCmdValidator : AbstractValidator<UpdateInsuranceCmd>
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public UpdateInsuranceCmdValidator(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;

            RuleFor(p => p.Id)
                 .NotNull()
                 .MustAsync(RecordMustExist);

            RuleFor(p => p.UserProfileId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.InsuranceCompanyName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters")
                .WithMessage("{PropertyName} must be unique.");

            RuleFor(p => p.PolicyNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters")
                .WithMessage("{PropertyName} must be unique.");

            RuleFor(p => p.PolicyRemarks)
               .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters")
               .WithMessage("{PropertyName} must be unique.");
        }
        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _insuranceRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
