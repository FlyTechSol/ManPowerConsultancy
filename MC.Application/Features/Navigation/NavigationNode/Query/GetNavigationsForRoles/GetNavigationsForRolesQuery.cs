using MC.Application.ModelDto.Navigation;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Query.GetNavigationsForRoles
{
   public record GetNavigationsForRolesQuery(List<string> Roles) : IRequest<List<NavigationNodeDto>>;
}
