using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Address.Command.Update
{
    public class UpdateAddressCmdHandler : IRequestHandler<UpdateAddressCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly IAppLogger<UpdateAddressCmdHandler> _logger;

        public UpdateAddressCmdHandler(IMapper mapper, IAddressRepository addressRepository, IAppLogger<UpdateAddressCmdHandler> logger)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateAddressCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _addressRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateAddressCmdValidator(_addressRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.Address), request.Id);
                throw new BadRequestException("Invalid address detail", validationResult);
            }

            //if (request.IsActive)
            //{
            //    var existingAddresses = await _addressRepository
            //        .GetAllByUserIdAsync(request.UserProfileId, cancellationToken);

            //    var addressesToDeactivate = existingAddresses
            //        .Where(a => a.Id != request.Id && a.IsActive)
            //        .ToList();

            //    foreach (var address in addressesToDeactivate)
            //    {
            //        address.IsActive = false;
            //    }

            //    if (addressesToDeactivate.Any())
            //        await _addressRepository.UpdateRangeAsync(addressesToDeactivate, cancellationToken);
            //}
            _mapper.Map(request, recordUpdateRequest);
            await _addressRepository.UpdateAsync(recordUpdateRequest, cancellationToken);
            // convert to domain entity object
            //var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            //// add to database
            //await _addressRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
