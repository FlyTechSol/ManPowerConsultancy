using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.BodyMeasurement.Command.Update
{
    public class UpdateBodyMeasCmdValidator : AbstractValidator<UpdateBodyMeasCmd>
    {
        private readonly IBodyMeasurementRepository _bodyMeasurementRepository;

        public UpdateBodyMeasCmdValidator(IBodyMeasurementRepository bodyMeasurementRepository)
        {
            _bodyMeasurementRepository = bodyMeasurementRepository;

            RuleFor(p => p.Id)
                 .NotNull()
                 .MustAsync(RecordMustExist);

            RuleFor(p => p.UserProfileId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Remark)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters")
                .WithMessage("{PropertyName} must be unique.");
        }
        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _bodyMeasurementRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
