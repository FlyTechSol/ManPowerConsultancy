using AutoMapper;
using MC.Application.Contracts.Persistence.Menu;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetById
{
    public class GetByIdMenuItemQueryHandler : IRequestHandler<GetByIdMenuItemQuery, MenuItemDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IMenuItemRepository _menuItemRepository;

        public GetByIdMenuItemQueryHandler(IMapper mapper, IMenuItemRepository menuItemRepository)
        {
            _mapper = mapper;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<MenuItemDetailDto> Handle(GetByIdMenuItemQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _menuItemRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(MenuItem), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<MenuItemDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
