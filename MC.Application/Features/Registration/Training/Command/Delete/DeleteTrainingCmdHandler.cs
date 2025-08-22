using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Training.Command.Delete
{
    public class DeleteTrainingCmdHandler : IRequestHandler<DeleteTrainingCmd, Unit>
    {
        private readonly ITrainingRepository _trainingRepository;

        public DeleteTrainingCmdHandler(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<Unit> Handle(DeleteTrainingCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _trainingRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Training), request.Id);

            // remove from database
            await _trainingRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
