using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Bank.Command.Delete
{
    public class DeleteBankCmdHandler : IRequestHandler<DeleteBankCmd, Unit>
    {
        private readonly IBankRepository _bankRepository;

        public DeleteBankCmdHandler(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<Unit> Handle(DeleteBankCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _bankRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(Bank), request.Id);

            // remove from database
            await _bankRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
