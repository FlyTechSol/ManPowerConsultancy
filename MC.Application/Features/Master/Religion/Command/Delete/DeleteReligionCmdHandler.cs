using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Religion.Command.Delete
{
    public class DeleteReligionCmdHandler : IRequestHandler<DeleteReligionCmd, Unit>
    {
        private readonly IReligionRepository _religionRepository;

        public DeleteReligionCmdHandler(IReligionRepository religionRepository)
        {
            _religionRepository = religionRepository;
        }

        public async Task<Unit> Handle(DeleteReligionCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _religionRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(Asset), request.Id);

            // remove from database
            await _religionRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
