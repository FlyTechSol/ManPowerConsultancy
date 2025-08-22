using MC.Application.Contracts.Persistence.Menu;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Menu.Menu.Command.Delete
{
    public class DeleteMenuCmdHandler : IRequestHandler<DeleteMenuCmd, Unit>
    {
        private readonly IMenuRepository _menuRepository;

        public DeleteMenuCmdHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<Unit> Handle(DeleteMenuCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var menuToDelete = await _menuRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (menuToDelete == null)
                throw new NotFoundException(nameof(Menu), request.Id);

            // remove from database
            await _menuRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
