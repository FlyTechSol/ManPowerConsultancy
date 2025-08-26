using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Command.Update
{
    public class UpdateBodyMeasCmdHandler : IRequestHandler<UpdateBodyMeasCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBodyMeasurementRepository _bodyMeasurementRepository;
        private readonly IAppLogger<UpdateBodyMeasCmdHandler> _logger;

        public UpdateBodyMeasCmdHandler(IMapper mapper, IBodyMeasurementRepository bodyMeasurementRepository, IAppLogger<UpdateBodyMeasCmdHandler> logger)
        {
            _mapper = mapper;
            _bodyMeasurementRepository = bodyMeasurementRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateBodyMeasCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _bodyMeasurementRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateBodyMeasCmdValidator(_bodyMeasurementRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.BodyMeasurement), request.Id);
                throw new BadRequestException("Invalid body measurement detail", validationResult);
            }
            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _bodyMeasurementRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
