using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.Family.Command.Update
{
    public class UpdateFamilyCmdValidator : AbstractValidator<UpdateFamilyCmd>
    {
        private readonly IFamilyRepository _familyRepository;

        public UpdateFamilyCmdValidator(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.RelationTo)
                .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.Address)
                .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters");
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _familyRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
