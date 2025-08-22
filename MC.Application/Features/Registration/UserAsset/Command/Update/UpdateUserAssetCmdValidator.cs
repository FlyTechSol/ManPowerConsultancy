using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.UserAsset.Command.Update
{
    public class UpdateUserAssetCmdValidator : AbstractValidator<UpdateUserAssetCmd>
    {
        private readonly IUserAssetRepository _userAssetRepository;

        public UpdateUserAssetCmdValidator(IUserAssetRepository userAssetRepository)
        {
            _userAssetRepository = userAssetRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.AssetId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.SerialNo)
                .MaximumLength(30).WithMessage("{PropertyName} must be fewer than 30 characters");

            RuleFor(p => p.Remarks)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _userAssetRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
