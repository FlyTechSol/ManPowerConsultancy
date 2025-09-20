using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.UserAsset.Command.UpdateStatus
{
    public class UpdateStatusUserAssetCmdValidator : AbstractValidator<UpdateStatusUserAssetCmd>
    {
        private readonly IUserAssetRepository _userAssetRepository;

        public UpdateStatusUserAssetCmdValidator(IUserAssetRepository userAssetRepository)
        {
            _userAssetRepository = userAssetRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.ReturnStatus)
                .NotNull().WithMessage("{PropertyName} is required.")
                .IsInEnum().WithMessage("A valid return type must be selected.");

            RuleFor(p => p.ReturnDate)
                 .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ReturnRemarks)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _userAssetRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
