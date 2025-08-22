using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.CasteCategory.Command.Update
{
    public class UpdateCasteCategoryCmdValidator : AbstractValidator<UpdateCasteCategoryCmd>
    {
        private readonly ICasteCategoryRepository _casteCategoryRepository;

        public UpdateCasteCategoryCmdValidator(ICasteCategoryRepository casteCategoryRepository)
        {
            _casteCategoryRepository = casteCategoryRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters")
                 .MustAsync((command, code, cancellationToken) =>
                    DecodeMustBeUniqueForUpdate(command.Id, code, cancellationToken))
                .WithMessage("{PropertyName} must be unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");
        }

        private async Task<bool> DecodeMustBeUniqueForUpdate(Guid id, string decode, CancellationToken cancellationToken)
        {
            var isUnique = await _casteCategoryRepository.IsUniqueForUpdate(id, decode, cancellationToken);
            return isUnique;
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var record = await _casteCategoryRepository.GetByIdAsync(id, cancellationToken);
            return record != null;
        }
    }
}
