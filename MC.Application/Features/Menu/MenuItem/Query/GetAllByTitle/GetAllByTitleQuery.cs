using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetAllByTitle
{
    public class GetAllByTitleQuery : IRequest<ApiResponse<PaginatedResponse<MenuItemTitleDto>>>
    {
        public QueryParams QueryParams { get; set; }
        public GetAllByTitleQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;

        }
    }
}
