using FluentValidation;
using MC.Application.Contracts.Persistence.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .MustAsync(MenuItemMustExist);

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.IconUrl)
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(256).WithMessage("{PropertyName} must be fewer than 256 characters");

        }

        private async Task<bool> MenuItemMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _menuItemRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
