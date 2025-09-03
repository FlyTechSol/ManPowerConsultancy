using FluentValidation;
using MC.Application.Contracts.Navigation;

namespace MC.Application.Features.Navigation.NavigationNode.Command.Update
{
    public class UpdateNavigationNodeCmdValidator : AbstractValidator<UpdateNavigationNodeCmd>
    {
        private readonly INavigationNodeRepository _repository;

        public UpdateNavigationNodeCmdValidator(INavigationNodeRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .MustAsync(NodeExists).WithMessage("Navigation node does not exist.");

            RuleFor(x => x.Title)
                .NotEmpty().MaximumLength(100);

            RuleFor(x => x.ParentId)
                .MustAsync(ParentNodeExists)
                .When(x => x.ParentId.HasValue)
                .WithMessage("Parent navigation node does not exist.");
        }

        private async Task<bool> NodeExists(Guid nodeId, CancellationToken token)
            => await _repository.ExistsAsync(nodeId, token);

        private async Task<bool> ParentNodeExists(Guid? parentId, CancellationToken token)
            => parentId == null || await _repository.ExistsAsync(parentId.Value, token);
    }
}
