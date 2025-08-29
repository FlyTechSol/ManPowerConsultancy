using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Command.Delete
{
    public class DeleteClientMasterCmdHandler : IRequestHandler<DeleteClientMasterCmd, MediatR.Unit>
    {
        private readonly IClientMasterRepository _clientMasterRepository;

        public DeleteClientMasterCmdHandler(IClientMasterRepository clientMasterRepository)
        {
            _clientMasterRepository = clientMasterRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteClientMasterCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _clientMasterRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(ClientMaster), request.Id);

            // remove from database
            await _clientMasterRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return MediatR.Unit.Value;
        }
    }
}
