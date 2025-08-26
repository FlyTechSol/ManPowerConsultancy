using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.BodyMeasurement.Command.Create
{
    public class CreateBodyMeasCmdValidator : AbstractValidator<CreateBodyMeasCmd>
    {
        private readonly IBodyMeasurementRepository _bodyMeasurementRepository;

        public CreateBodyMeasCmdValidator(IBodyMeasurementRepository bodyMeasurementRepository)
        {
            _bodyMeasurementRepository = bodyMeasurementRepository;

            RuleFor(p => p.UserProfileId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Remark)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }
    }
}
