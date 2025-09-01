using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetAll
{
   public class GetAllMenuItemQueryHandler : IRequestHandler<GetAllMenuItemQuery, ApiResponse<PaginatedResponse<MenuItemDto>>> 
    {
        private readonly IMenuItemRepository _menuItemRepository;
        public GetAllMenuItemQueryHandler(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<MenuItemDto>>> Handle(GetAllMenuItemQuery request, CancellationToken cancellationToken)
        {
            var record = await _menuItemRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<MenuItemDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
