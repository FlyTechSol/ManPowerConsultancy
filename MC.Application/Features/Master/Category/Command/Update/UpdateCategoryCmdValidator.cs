using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Category.Command.Update
{
   public class UpdateCategoryCmdValidator : AbstractValidator<UpdateCategoryCmd>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCmdValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters")
                 .MustAsync((command, code, cancellationToken) =>
                    RecordMustBeUniqueForUpdate(command.Id, code, cancellationToken))
                .WithMessage("{PropertyName} must be unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");
        }

        private async Task<bool> RecordMustBeUniqueForUpdate(Guid id, string code, CancellationToken cancellationToken)
        {
            var isUnique = await _categoryRepository.IsUniqueForUpdate(id, code, cancellationToken);
            return isUnique;
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var record = await _categoryRepository.GetByIdAsync(id, cancellationToken);
            return record != null;
        }
    }
}
