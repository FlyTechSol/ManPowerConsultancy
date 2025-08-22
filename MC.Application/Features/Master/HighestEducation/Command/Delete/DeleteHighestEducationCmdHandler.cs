using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.HighestEducation.Command.Delete
{
    public class DeleteHighestEducationCmdHandler : IRequestHandler<DeleteHighestEducationCmd, Unit>
    {
        private readonly IHighestEducationRepository _highestEducationRepository;

        public DeleteHighestEducationCmdHandler(IHighestEducationRepository highestEducationRepository)
        {
            _highestEducationRepository = highestEducationRepository;
        }

        public async Task<Unit> Handle(DeleteHighestEducationCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _highestEducationRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(HighestEducation), request.Id);

            // remove from database
            await _highestEducationRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
