using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Menu;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Menu.Menu.Command.Update
{
   public class UpdateMenuCmdHandler : IRequestHandler<UpdateMenuCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;
        private readonly IAppLogger<UpdateMenuCmdHandler> _logger;

        public UpdateMenuCmdHandler(IMapper mapper, IMenuRepository menuRepository, IAppLogger<UpdateMenuCmdHandler> logger)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateMenuCmd request, CancellationToken cancellationToken)
        {
            var menuUpdateRequest = await _menuRepository.GetByIdAsync(request.Id, cancellationToken);

            if (menuUpdateRequest is null)
                throw new NotFoundException(nameof(menuUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateMenuCmdValidator(_menuRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Menu), request.Id);
                throw new BadRequestException("Invalid menu", validationResult);
            }

            // convert to domain entity object
            var menuToUpdate = _mapper.Map(request, menuUpdateRequest);

            // add to database
            await _menuRepository.UpdateAsync(menuToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
