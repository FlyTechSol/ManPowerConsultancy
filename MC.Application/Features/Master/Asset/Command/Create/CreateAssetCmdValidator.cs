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
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters")
                .MustAsync(CodeMustBeUnique).WithMessage("Code must be unique");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");
        }

        private Task<bool> CodeMustBeUnique(string code, CancellationToken token)
        {
            return _assetRepository.IsUnique(code, token);
        }
    }
}
