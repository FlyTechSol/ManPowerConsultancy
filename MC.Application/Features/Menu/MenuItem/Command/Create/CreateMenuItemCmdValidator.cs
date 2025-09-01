using FluentValidation;
using MC.Application.Contracts.Persistence.Menu;

namespace MC.Application.Features.Menu.MenuItem.Command.Create
{
    public class CreateMenuItemCmdValidator : AbstractValidator<CreateMenuItemCmd>
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public CreateMenuItemCmdValidator(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(256).WithMessage("{PropertyName} must be fewer than 256 characters");

            RuleFor(p => p.IconUrl)
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.RoleId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.MenuId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(q => q)
                .MustAsync(RecordMustUnique)
                .WithMessage("A menu item with the same title already exists for this menu and role");
        }

        private Task<bool> RecordMustUnique(CreateMenuItemCmd command, CancellationToken token)
        {
            return _menuItemRepository.IsUnique(command.Title, command.MenuId, command.RoleId, token);
        }
    }
}
