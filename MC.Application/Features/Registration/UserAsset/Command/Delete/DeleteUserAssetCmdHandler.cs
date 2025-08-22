using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Command.Delete
{
    public class DeleteUserAssetCmdHandler : IRequestHandler<DeleteUserAssetCmd, Unit>
    {
        private readonly IUserAssetRepository _userAssetRepository;

        public DeleteUserAssetCmdHandler(IUserAssetRepository userAssetRepository)
        {
            _userAssetRepository = userAssetRepository;
        }

        public async Task<Unit> Handle(DeleteUserAssetCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _userAssetRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.UserAsset), request.Id);

            // remove from database
            await _userAssetRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
