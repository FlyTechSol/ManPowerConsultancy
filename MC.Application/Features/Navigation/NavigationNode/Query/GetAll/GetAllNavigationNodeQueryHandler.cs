using MC.Application.Contracts.Navigation;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Navigation;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Query.GetAll
{
    public class GetAllNavigationNodeQueryHandler : IRequestHandler<GetAllNavigationNodeQuery, ApiResponse<PaginatedResponse<NavigationNodeDto>>>
    {
        private readonly INavigationNodeRepository _repository;

        public GetAllNavigationNodeQueryHandler(INavigationNodeRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<PaginatedResponse<NavigationNodeDto>>> Handle(GetAllNavigationNodeQuery request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetAllAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<NavigationNodeDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
