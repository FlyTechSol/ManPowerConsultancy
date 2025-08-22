using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Gender.Command.Delete
{
    public class DeleteGenderCmdHandler : IRequestHandler<DeleteGenderCmd, Unit>
    {
        private readonly IGenderRepository _genderRepository;

        public DeleteGenderCmdHandler(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<Unit> Handle(DeleteGenderCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _genderRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(Gender), request.Id);

            // remove from database
            await _genderRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
