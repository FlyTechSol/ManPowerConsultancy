using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Communication.Command.Delete
{
    public class DeleteCommunicationCmdHandler : IRequestHandler<DeleteCommunicationCmd, Unit>
    {
        private readonly ICommunicationRepository _communicationRepository;

        public DeleteCommunicationCmdHandler(ICommunicationRepository communicationRepository)
        {
            _communicationRepository = communicationRepository;
        }

        public async Task<Unit> Handle(DeleteCommunicationCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _communicationRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Communication), request.Id);

            // remove from database
            await _communicationRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
