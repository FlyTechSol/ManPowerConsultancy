using MC.Application.Contracts.Navigation;
using MC.Application.ModelDto.Navigation;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Query.GetNavigationsForRoles
{
    public class GetNavigationsForRolesQueryHandler : IRequestHandler<GetNavigationsForRolesQuery, List<NavigationNodeDto>>
    {
        private readonly INavigationNodeRepository _navigationNodeRepository;

        public GetNavigationsForRolesQueryHandler(INavigationNodeRepository navigationNodeRepository)
        {
            _navigationNodeRepository = navigationNodeRepository;
        }

        public async Task<List<NavigationNodeDto>> Handle(GetNavigationsForRolesQuery request, CancellationToken cancellationToken)
        {
            return await _navigationNodeRepository.GetNavigationsForRolesAsync(request.Roles, cancellationToken);
        }
    }

}
