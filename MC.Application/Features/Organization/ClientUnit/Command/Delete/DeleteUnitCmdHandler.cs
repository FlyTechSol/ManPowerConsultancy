using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Command.Delete
{
    public class DeleteUnitCmdHandler : IRequestHandler<DeleteUnitCmd, Unit>
    {
        private readonly IUnitRepository _unitRepository;

        public DeleteUnitCmdHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<Unit> Handle(DeleteUnitCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _unitRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(ClientUnit), request.Id);

            // remove from database
            await _unitRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
