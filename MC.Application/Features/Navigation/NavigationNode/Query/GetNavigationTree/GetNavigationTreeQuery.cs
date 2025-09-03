using MC.Application.ModelDto.Navigation;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Query.GetNavigationTree
{
    public record GetNavigationTreeQuery() : IRequest<List<NavigationNodeDto>>;
}
