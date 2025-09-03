using MC.Application.Contracts.Navigation;
using MC.Application.ModelDto.Navigation;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Query.GetNavigationTree
{
    public class GetNavigationTreeQueryHandler : IRequestHandler<GetNavigationTreeQuery, List<NavigationNodeDto>>
    {
        private readonly INavigationNodeRepository _navigationNodeRepository;

        public GetNavigationTreeQueryHandler(INavigationNodeRepository navigationNodeRepository)
        {
            _navigationNodeRepository = navigationNodeRepository;
        }

        public async Task<List<NavigationNodeDto>> Handle(GetNavigationTreeQuery request, CancellationToken cancellationToken)
        {
            return await _navigationNodeRepository.GetTreeAsync(cancellationToken);
        }
    }

}
