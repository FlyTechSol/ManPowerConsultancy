using MC.Application.Contracts.Persistence.Menu;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Command.Delete
{
    public class DeleteMenuItemCmdHandler : IRequestHandler<DeleteMenuItemCmd, Unit>
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public DeleteMenuItemCmdHandler(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<Unit> Handle(DeleteMenuItemCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var menuItemToDelete = await _menuItemRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (menuItemToDelete == null)
                throw new NotFoundException(nameof(MenuItem), request.Id);

            // remove from database
            await _menuItemRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
