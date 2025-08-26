using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Command.Delete
{
    public class DeleteBankAccountCmdHandler : IRequestHandler<DeleteBankAccountCmd, Unit>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public DeleteBankAccountCmdHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<Unit> Handle(DeleteBankAccountCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _bankAccountRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.BankAccount), request.Id);

            // remove from database
            await _bankAccountRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
