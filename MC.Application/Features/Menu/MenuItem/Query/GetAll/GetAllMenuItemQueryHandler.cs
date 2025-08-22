using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetAll
{
   public class GetAllMenuItemQueryHandler : IRequestHandler<GetAllMenuItemQuery, List<MenuItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IAppLogger<GetAllMenuItemQueryHandler> _logger;

        public GetAllMenuItemQueryHandler(IMapper mapper,
            IMenuItemRepository menuItemRepository,
            IAppLogger<GetAllMenuItemQueryHandler> logger)
        {
            _mapper = mapper;
            _menuItemRepository = menuItemRepository;
            _logger = logger;
        }

        public async Task<List<MenuItemDto>> Handle(GetAllMenuItemQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _menuItemRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<MenuItemDto>>(response);

            // return list of DTO object
            _logger.LogInformation("Menu item were retrieved successfully");
            return data;
        }
    }
}
