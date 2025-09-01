using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetAllByTitle
{
    public class GetAllByTitleQueryHandler : IRequestHandler<GetAllByTitleQuery, ApiResponse<PaginatedResponse<MenuItemTitleDto>>>
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public GetAllByTitleQueryHandler(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<MenuItemTitleDto>>> Handle(GetAllByTitleQuery request, CancellationToken cancellationToken)
        {
            var record = await _menuItemRepository.GetAllMenuTitleAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<MenuItemTitleDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
