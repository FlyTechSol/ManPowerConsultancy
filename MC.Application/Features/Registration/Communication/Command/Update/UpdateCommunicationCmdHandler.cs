using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Communication.Command.Update
{
    public class UpdateCommunicationCmdHandler : IRequestHandler<UpdateCommunicationCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICommunicationRepository _communicationRepository;
        private readonly IAppLogger<UpdateCommunicationCmdHandler> _logger;

        public UpdateCommunicationCmdHandler(IMapper mapper, ICommunicationRepository communicationRepository, IAppLogger<UpdateCommunicationCmdHandler> logger)
        {
            _mapper = mapper;
            _communicationRepository = communicationRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCommunicationCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _communicationRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateCommunicationCmdValidator(_communicationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.Communication), request.Id);
                throw new BadRequestException("Invalid communication detail", validationResult);
            }
            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _communicationRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
