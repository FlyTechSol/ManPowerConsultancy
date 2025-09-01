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
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            //RuleFor(p => p.NavigationURL)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .NotNull()
            //    .MaximumLength(256).WithMessage("{PropertyName} must be fewer than 256 characters");

            RuleFor(p => p.IconUrl)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(q => q)
                  .MustAsync(TitleMustUnique)
                  .WithMessage("Title already exists");
        }

        private Task<bool> TitleMustUnique(CreateMenuCmd command, CancellationToken token)
        {
            return _menuRepository.IsUnique(command.Title, token);
        }
    }
}
