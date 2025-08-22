using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.Training.Command.Update
{
    public class UpdateTrainingCmdValidator : AbstractValidator<UpdateTrainingCmd>
    {
        private readonly ITrainingRepository _trainingRepository;

        public UpdateTrainingCmdValidator(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.TrainingName)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.TrainingInstitute)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                 .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.TrainingRemarks)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(p => p.TrainingCertificateUrl)
                .MaximumLength(256).WithMessage("{PropertyName} must be fewer than 256 characters");
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _trainingRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
