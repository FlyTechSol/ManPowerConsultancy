using FluentValidation;
using MC.Application.Contracts.Persistence.Menu;

namespace MC.Application.Features.Menu.MenuItem.Command.Update
{
    public class UpdateMenuItemCmdValidator : AbstractValidator<UpdateMenuItemCmd>
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public UpdateMenuItemCmdValidator(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(RecordMustExist);

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

            RuleFor(cmd => cmd)
                .MustAsync(RecordMustBeUnique)
                .WithMessage("A menu item with the same title already exists for this menu and role.");
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _menuItemRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
        private Task<bool> RecordMustBeUnique(UpdateMenuItemCmd command, CancellationToken token)
        {
            return _menuItemRepository.IsUniqueForUpdate(command.Id, command.Title, command.MenuId, command.RoleId, token);
        }
    }
}
