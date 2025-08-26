using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.SecurityDeposit.Command.Delete
{
    public class DeleteSecurityDepositCmdHandler : IRequestHandler<DeleteSecurityDepositCmd, Unit>
    {
        private readonly ISecurityDepositRepository _securityDepositRepository;

        public DeleteSecurityDepositCmdHandler(ISecurityDepositRepository securityDepositRepository)
        {
            _securityDepositRepository = securityDepositRepository;
        }

        public async Task<Unit> Handle(DeleteSecurityDepositCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _securityDepositRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.SecurityDeposit), request.Id);

            // remove from database
            await _securityDepositRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
