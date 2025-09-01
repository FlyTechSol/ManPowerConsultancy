using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetMenuItemByMenuId
{
    public class GetMenuItemByMenuIdQuery : IRequest<ApiResponse<PaginatedResponse<MenuItemDto>>>
    {
        public QueryParams QueryParams { get; set; }
        public Guid MenuId { get; set; }

        public GetMenuItemByMenuIdQuery(QueryParams queryParams, Guid menuId)
        {
            QueryParams = queryParams;
            MenuId = menuId;
        }
    }
}
