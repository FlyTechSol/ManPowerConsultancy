using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.ZipCode.Command.Delete
{
    public class DeleteZipCodeCmdHandler : IRequestHandler<DeleteZipCodeCmd, Unit>
    {
        private readonly IZipCodeRepository _zipCodeRepository;
        public DeleteZipCodeCmdHandler(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }

        public async Task<Unit> Handle(DeleteZipCodeCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var locationToDelete = await _zipCodeRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (locationToDelete == null)
                throw new NotFoundException(nameof(ZipCode), request.Id);

            // remove from database
            await _zipCodeRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
