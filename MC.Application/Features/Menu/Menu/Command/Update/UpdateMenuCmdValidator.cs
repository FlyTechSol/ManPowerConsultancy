using FluentValidation;
using MC.Application.Contracts.Persistence.Menu;

namespace MC.Application.Features.Menu.Menu.Command.Update
{
    public class UpdateMenuCmdValidator : AbstractValidator<UpdateMenuCmd>
    {
        private readonly IMenuRepository _menuRepository;

        public UpdateMenuCmdValidator(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(MenuMustExist).WithMessage("Menu does not exist.");

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.IconUrl)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            //RuleFor(p => p.NavigationURL)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .NotNull()
            //    .MaximumLength(256).WithMessage("{PropertyName} must be fewer than 256 characters");

            // Uniqueness check on menu title
            RuleFor(cmd => cmd)
                .MustAsync(RecordMustBeUnique)
                .WithMessage("A menu with the same title already exists.");
        }

        private async Task<bool> MenuMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _menuRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }

        private Task<bool> RecordMustBeUnique(UpdateMenuCmd command, CancellationToken cancellationToken)
        {
            return _menuRepository.IsUniqueForUpdate(command.Id, command.Title, cancellationToken);
        }
    }

}
