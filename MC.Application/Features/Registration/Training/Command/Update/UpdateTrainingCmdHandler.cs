using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Training.Command.Update
{
    public class UpdateTrainingCmdHandler : IRequestHandler<UpdateTrainingCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _trainingRepository;
        private readonly IAppLogger<UpdateTrainingCmdHandler> _logger;

        public UpdateTrainingCmdHandler(IMapper mapper, ITrainingRepository trainingRepository, IAppLogger<UpdateTrainingCmdHandler> logger)
        {
            _mapper = mapper;
            _trainingRepository = trainingRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateTrainingCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _trainingRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateTrainingCmdValidator(_trainingRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.Training), request.Id);
                throw new BadRequestException("Invalid training detail", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _trainingRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
