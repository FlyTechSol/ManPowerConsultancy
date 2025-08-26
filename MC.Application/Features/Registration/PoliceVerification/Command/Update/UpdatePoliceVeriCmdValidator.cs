using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.PoliceVerification.Command.Update
{
    public class UpdatePoliceVeriCmdValidator : AbstractValidator<UpdatePoliceVeriCmd>
    {
        private readonly IPoliceVerificationRepository _policeVerificationRepository;

        public UpdatePoliceVeriCmdValidator(IPoliceVerificationRepository policeVerificationRepository)
        {
            _policeVerificationRepository = policeVerificationRepository;

            RuleFor(p => p.Id)
                 .NotNull()
                 .MustAsync(RecordMustExist);

            RuleFor(p => p.UserProfileId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.PoliceStationName)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                 .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.VerificationRemarks)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }
        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _policeVerificationRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
