using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Address.Command.Create
{
    public class CreateAddressCmdHandler : IRequestHandler<CreateAddressCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public CreateAddressCmdHandler(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<Guid> Handle(CreateAddressCmd request, CancellationToken cancellationToken)
        {
            // 1. Validate request
            var validator = new CreateAddressCmdValidator(_addressRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid address record", validationResult);

            // 2. Deactivate all existing addresses for this user
            var existingAddresses = await _addressRepository
                .GetAllByUserIdAsync(request.UserProfileId, cancellationToken);

            foreach (var addr in existingAddresses.Where(a => a.IsActive))
            {
                addr.IsActive = false;
            }

            // 3. Map new address and set IsActive = true
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.Address>(request);
            recordToCreate.IsActive = true;

            // 4. Save all changes (update + create)
            await _addressRepository.CreateAsync(recordToCreate, cancellationToken);

            if (existingAddresses.Any())
            {
                await _addressRepository.UpdateRangeAsync(existingAddresses, cancellationToken);
            }

            // 5. Return the new address Id
            return recordToCreate.Id;
        }
    }
}
