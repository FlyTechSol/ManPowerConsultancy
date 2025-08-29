using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Branch.Command.Delete
{
    public class DeleteBranchCmdHandler : IRequestHandler<DeleteBranchCmd, Unit>
    {
        private readonly IBranchRepository _branchRepository;

        public DeleteBranchCmdHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<Unit> Handle(DeleteBranchCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _branchRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(Branch), request.Id);

            // remove from database
            await _branchRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
