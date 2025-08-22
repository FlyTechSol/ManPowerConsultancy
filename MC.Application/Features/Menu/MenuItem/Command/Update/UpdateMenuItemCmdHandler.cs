using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Menu;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Command.Update
{
    public class UpdateMenuItemCmdHandler : IRequestHandler<UpdateMenuItemCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IAppLogger<UpdateMenuItemCmdHandler> _logger;

        public UpdateMenuItemCmdHandler(IMapper mapper, IMenuItemRepository menuItemRepository, IAppLogger<UpdateMenuItemCmdHandler> logger)
        {
            _mapper = mapper;
            _menuItemRepository = menuItemRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateMenuItemCmd request, CancellationToken cancellationToken)
        {
            var menuItemUpdateRequest = await _menuItemRepository.GetByIdAsync(request.Id, cancellationToken);

            if (menuItemUpdateRequest is null)
                throw new NotFoundException(nameof(menuItemUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateMenuItemCmdValidator(_menuItemRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(MenuItem), request.Id);
                throw new BadRequestException("Invalid menu item", validationResult);
            }

            // convert to domain entity object
            var menuItemToUpdate = _mapper.Map(request, menuItemUpdateRequest);

            // add to database
            await _menuItemRepository.UpdateAsync(menuItemToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
