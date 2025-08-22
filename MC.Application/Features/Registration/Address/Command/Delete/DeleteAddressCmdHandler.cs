using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Address.Command.Delete
{
   public class DeleteAddressCmdHandler : IRequestHandler<DeleteAddressCmd, Unit>
    {
        private readonly IAddressRepository _addressRepository;

        public DeleteAddressCmdHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Unit> Handle(DeleteAddressCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _addressRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Address), request.Id);

            // remove from database
            await _addressRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
