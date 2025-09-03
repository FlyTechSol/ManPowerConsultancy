using FluentValidation;
using MC.Application.Contracts.Navigation;

namespace MC.Application.Features.Navigation.NavigationNode.Command.Create
{
    public class CreateNavigationNodeCmdValidator : AbstractValidator<CreateNavigationNodeCmd>
    {
        private readonly INavigationNodeRepository _repository;

        public CreateNavigationNodeCmdValidator(INavigationNodeRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100);

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0);

            RuleForEach(x => x.RoleIds)
                .NotEmpty().WithMessage("RoleId cannot be empty.");

            RuleFor(x => x.ParentId)
                .MustAsync(ParentNodeExists).When(x => x.ParentId.HasValue)
                .WithMessage("Parent navigation node does not exist.");
        }

        private async Task<bool> ParentNodeExists(Guid? parentId, CancellationToken cancellationToken)
        {
            return parentId == null || await _repository.ExistsAsync(parentId.Value, cancellationToken);
        }
    }
}