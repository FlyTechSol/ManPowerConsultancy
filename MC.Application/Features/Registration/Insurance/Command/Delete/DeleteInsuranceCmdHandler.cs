using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Insurance.Command.Delete
{
    public class DeleteInsuranceCmdHandler : IRequestHandler<DeleteInsuranceCmd, Unit>
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public DeleteInsuranceCmdHandler(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public async Task<Unit> Handle(DeleteInsuranceCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _insuranceRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Insurance), request.Id);

            // remove from database
            await _insuranceRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
