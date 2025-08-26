using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Asset.Command.Delete
{
    public class DeleteAssetCmdHandler : IRequestHandler<DeleteAssetCmd, Unit>
    {
        private readonly IAssetRepository _assetRepository;

        public DeleteAssetCmdHandler(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<Unit> Handle(DeleteAssetCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _assetRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(Asset), request.Id);

            // remove from database
            await _assetRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
