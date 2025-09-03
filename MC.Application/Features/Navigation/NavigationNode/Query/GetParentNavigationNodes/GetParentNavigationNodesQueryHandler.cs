using MC.Application.Contracts.Navigation;
using MC.Application.ModelDto.Navigation;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Query.GetParentNavigationNodes
{
   public class GetParentNavigationNodesQueryHandler
    : IRequestHandler<GetParentNavigationNodesQuery, List<NavigationNodeDropdownDto>>
    {
        private readonly INavigationNodeRepository _repository;

        public GetParentNavigationNodesQueryHandler(INavigationNodeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<NavigationNodeDropdownDto>> Handle(GetParentNavigationNodesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetParentNodesAsync(request.ExcludeId, cancellationToken);
        }
    }
}
