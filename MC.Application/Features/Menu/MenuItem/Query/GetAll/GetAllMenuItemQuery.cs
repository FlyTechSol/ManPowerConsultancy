using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetAll
{
    public class GetAllMenuItemQuery : IRequest<ApiResponse<PaginatedResponse<MenuItemDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllMenuItemQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
