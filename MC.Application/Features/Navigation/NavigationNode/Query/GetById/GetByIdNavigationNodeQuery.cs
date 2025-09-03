using MC.Application.ModelDto.Navigation;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Query.GetById
{
   public record GetByIdNavigationNodeQuery(Guid Id) : IRequest<NavigationNodeDto>;
}
