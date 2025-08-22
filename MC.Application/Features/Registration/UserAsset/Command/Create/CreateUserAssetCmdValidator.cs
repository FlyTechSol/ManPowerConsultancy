using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.UserAsset.Command.Create
{
    public class CreateUserAssetCmdValidator : AbstractValidator<CreateUserAssetCmd>
    {
        private readonly IUserAssetRepository _userAssetRepository;

        public CreateUserAssetCmdValidator(IUserAssetRepository userAssetRepository)
        {
            _userAssetRepository = userAssetRepository;

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.AssetId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.SerialNo)
                .MaximumLength(30).WithMessage("{PropertyName} must be fewer than 30 characters");

            RuleFor(p => p.Remarks)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }
    }
}
