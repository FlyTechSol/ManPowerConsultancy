using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Command.Delete
{
    public class DeleteExArmyCmdHandler : IRequestHandler<DeleteExArmyCmd, Unit>
    {
        private readonly IExArmyRepository _exArmyRepository;

        public DeleteExArmyCmdHandler(IExArmyRepository exArmyRepository)
        {
            _exArmyRepository = exArmyRepository;
        }

        public async Task<Unit> Handle(DeleteExArmyCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _exArmyRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.ExArmy), request.Id);

            // remove from database
            await _exArmyRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
