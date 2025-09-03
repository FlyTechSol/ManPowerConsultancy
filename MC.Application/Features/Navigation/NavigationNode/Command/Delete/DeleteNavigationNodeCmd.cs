using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Command.Delete
{
    public class DeleteNavigationNodeCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
