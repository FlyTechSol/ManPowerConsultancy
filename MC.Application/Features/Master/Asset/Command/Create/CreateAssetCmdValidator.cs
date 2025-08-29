using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Asset.Command.Create
{
    public class CreateAssetCmdValidator : AbstractValidator<CreateAssetCmd>
    {
        private readonly IAssetRepository _assetRepository;

        public CreateAssetCmdValidator(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(q => q)
                .MustAsync(RecordMustUnique)
                .WithMessage("Asset record already exists");
        }

        private Task<bool> RecordMustUnique(CreateAssetCmd command, CancellationToken token)
        {
            return _assetRepository.IsUnique(command.Code, token);
        }
    }
}
