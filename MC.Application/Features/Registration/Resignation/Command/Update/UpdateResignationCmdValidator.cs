using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.Resignation.Command.Update
{
    public class UpdateResignationCmdValidator : AbstractValidator<UpdateResignationCmd>
    {
        private readonly IResignationRepository _resignationRepository;

        public UpdateResignationCmdValidator(IResignationRepository resignationRepository)
        {
            _resignationRepository = resignationRepository;

            RuleFor(p => p.Id)
                 .NotNull()
                 .MustAsync(RecordMustExist);

            RuleFor(p => p.UserProfileId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Reason)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }
        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _resignationRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
