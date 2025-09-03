using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Navigation;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Query.GetAll
{
    public class GetAllNavigationNodeQuery : IRequest<ApiResponse<PaginatedResponse<NavigationNodeDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllNavigationNodeQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
