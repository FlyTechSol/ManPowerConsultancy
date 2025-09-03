using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Command.Create
{
    public class CreateNavigationNodeCmd : IRequest<Guid>
    {
        public string Title { get; init; } = string.Empty;
        public string Url { get; init; } = string.Empty;
        public string IconUrl { get; init; } = string.Empty;
        public int DisplayOrder { get; init; }
        public Guid? ParentId { get; init; }
        public List<Guid> RoleIds { get; init; } = new();
    }
}
