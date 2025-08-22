using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Command.Delete
{
    public class DeleteInsNomineeCmdHandler : IRequestHandler<DeleteInsNomineeCmd, Unit>
    {
        private readonly IInsuranceNomineeRepository _insuranceNomineeRepository;

        public DeleteInsNomineeCmdHandler(IInsuranceNomineeRepository insuranceNomineeRepository)
        {
            _insuranceNomineeRepository = insuranceNomineeRepository;
        }

        public async Task<Unit> Handle(DeleteInsNomineeCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _insuranceNomineeRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.InsuranceNominee), request.Id);

            // remove from database
            await _insuranceNomineeRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
