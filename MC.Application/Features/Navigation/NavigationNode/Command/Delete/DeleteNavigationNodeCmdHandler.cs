using MC.Application.Contracts.Navigation;
using MC.Application.Exceptions;
using MC.Domain.Entity.Navigation;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Command.Delete
{
    public class DeleteNavigationNodeCmdHandler : IRequestHandler<DeleteNavigationNodeCmd, Unit>
    {
        private readonly INavigationNodeRepository _navigationNodeRepository;

        public DeleteNavigationNodeCmdHandler(INavigationNodeRepository navigationNodeRepository)
        {
            _navigationNodeRepository = navigationNodeRepository;
        }

        public async Task<Unit> Handle(DeleteNavigationNodeCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _navigationNodeRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(NavigationNode), request.Id);

            // remove from database
            await _navigationNodeRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
