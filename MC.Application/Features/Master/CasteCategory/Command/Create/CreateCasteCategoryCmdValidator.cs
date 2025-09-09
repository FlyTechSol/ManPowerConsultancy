using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.CasteCategory.Command.Create
{
    public class CreateCasteCategoryCmdValidator : AbstractValidator<CreateCasteCategoryCmd>
    {
        private readonly ICasteCategoryRepository _casteCategoryRepository;

        public CreateCasteCategoryCmdValidator(ICasteCategoryRepository casteCategoryRepository)
        {
            _casteCategoryRepository = casteCategoryRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters")
                .MustAsync(CodeMustBeUnique).WithMessage("Code must be unique");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            //RuleFor(q => q)
            //    .MustAsync(CodeMustUnique)
            //    .WithMessage("Caste category record already exists");
        }

        private Task<bool> CodeMustBeUnique(string code, CancellationToken token)
        {
            return _casteCategoryRepository.IsUnique(code, token);
        }
    }
}
