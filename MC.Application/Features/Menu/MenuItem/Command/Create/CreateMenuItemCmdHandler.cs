using AutoMapper;
using MC.Application.Contracts.Persistence.Menu;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Command.Create
{
    public class CreateMenuItemCmdHandler : IRequestHandler<CreateMenuItemCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IMenuItemRepository _menuItemRepository;

        public CreateMenuItemCmdHandler(IMapper mapper, IMenuItemRepository menuItemRepository)
        {
            _mapper = mapper;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<Guid> Handle(CreateMenuItemCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateMenuItemCmdValidator(_menuItemRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid menu item", validationResult);

            // convert to domain entity object
            var menuItemToCreate = _mapper.Map<Domain.Entity.Menu.MenuItem>(request);

            // add to database
            await _menuItemRepository.CreateAsync(menuItemToCreate, cancellationToken);

            // retun record id
            return menuItemToCreate.Id;
        }
    }
}
