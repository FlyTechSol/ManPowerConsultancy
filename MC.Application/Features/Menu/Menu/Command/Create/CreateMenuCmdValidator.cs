using FluentValidation;
using MC.Application.Contracts.Persistence.Menu;

namespace MC.Application.Features.Menu.Menu.Command.Create
{
    public class CreateMenuCmdValidator : AbstractValidator<CreateMenuCmd>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCmdValidator(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters")
                .MustAsync(TitleMustBeUnique).WithMessage("Title must be unique");

            //RuleFor(p => p.NavigationURL)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .NotNull()
            //    .MaximumLength(256).WithMessage("{PropertyName} must be fewer than 256 characters");

            RuleFor(p => p.IconUrl)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

        }

        private Task<bool> TitleMustBeUnique(string code, CancellationToken token)
        {
            return _menuRepository.IsUnique(code, token);
        }
    }
}
