using MC.Application.ModelDto.Navigation;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Query.GetParentNavigationNodes
{
  public record GetParentNavigationNodesQuery(Guid? ExcludeId = null) : IRequest<List<NavigationNodeDropdownDto>>;
}
