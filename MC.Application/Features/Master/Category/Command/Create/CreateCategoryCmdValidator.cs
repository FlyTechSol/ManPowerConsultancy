using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Category.Command.Create
{
   public class CreateCategoryCmdValidator : AbstractValidator<CreateCategoryCmd>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCmdValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(q => q)
                .MustAsync(RecordMustUnique)
                .WithMessage("Category record already exists");
        }

        private Task<bool> RecordMustUnique(CreateCategoryCmd command, CancellationToken token)
        {
            return _categoryRepository.IsUnique(command.Code, token);
        }
    }
}
