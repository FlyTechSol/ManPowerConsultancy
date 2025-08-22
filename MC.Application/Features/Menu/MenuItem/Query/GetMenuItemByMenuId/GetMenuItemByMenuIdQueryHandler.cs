using AutoMapper;
using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetMenuItemByMenuId
{
    public class GetMenuItemByMenuIdQueryHandler : IRequestHandler<GetMenuItemByMenuIdQuery, List<MenuItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMenuItemRepository _menuItemRepository;

        public GetMenuItemByMenuIdQueryHandler(IMapper mapper, IMenuItemRepository menuItemRepository)
        {
            _mapper = mapper;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<List<MenuItemDto>> Handle(GetMenuItemByMenuIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _menuItemRepository.GetMenuItemByMenuIdAsync(request.MenuId, cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<MenuItemDto>>(response);

            // return list of DTO object
             return data;
        }
    }
}
