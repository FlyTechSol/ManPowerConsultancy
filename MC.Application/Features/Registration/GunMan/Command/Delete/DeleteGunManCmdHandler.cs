using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.GunMan.Command.Delete
{
    public class DeleteGunManCmdHandler : IRequestHandler<DeleteGunManCmd, Unit>
    {
        private readonly IGunManRepository _gunManRepository;

        public DeleteGunManCmdHandler(IGunManRepository gunManRepository)
        {
            _gunManRepository = gunManRepository;
        }

        public async Task<Unit> Handle(DeleteGunManCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _gunManRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.GunMan), request.Id);

            // remove from database
            await _gunManRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
