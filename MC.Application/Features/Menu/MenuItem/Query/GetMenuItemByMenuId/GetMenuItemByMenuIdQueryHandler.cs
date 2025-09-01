using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetMenuItemByMenuId
{
    public class GetMenuItemByMenuIdQueryHandler : IRequestHandler<GetMenuItemByMenuIdQuery, ApiResponse<PaginatedResponse<MenuItemDto>>>
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public GetMenuItemByMenuIdQueryHandler(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<MenuItemDto>>> Handle(GetMenuItemByMenuIdQuery request, CancellationToken cancellationToken)
        {
            var record = await _menuItemRepository.GetMenuItemByMenuIdAsync(request.QueryParams, request.MenuId, cancellationToken);

            return new ApiResponse<PaginatedResponse<MenuItemDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
