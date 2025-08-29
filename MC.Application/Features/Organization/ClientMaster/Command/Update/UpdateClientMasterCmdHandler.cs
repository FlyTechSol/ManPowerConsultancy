using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Command.Update
{
    public class UpdateClientMasterCmdHandler : IRequestHandler<UpdateClientMasterCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IClientMasterRepository _clientMasterRepository;
        private readonly IAppLogger<UpdateClientMasterCmdHandler> _logger;

        public UpdateClientMasterCmdHandler(IMapper mapper, IClientMasterRepository clientMasterRepository, IAppLogger<UpdateClientMasterCmdHandler> logger)
        {
            _mapper = mapper;
            _clientMasterRepository = clientMasterRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateClientMasterCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _clientMasterRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateClientMasterCmdValidator(_clientMasterRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(ClientMaster), request.Id);
                throw new BadRequestException("Invalid client master type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _clientMasterRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
