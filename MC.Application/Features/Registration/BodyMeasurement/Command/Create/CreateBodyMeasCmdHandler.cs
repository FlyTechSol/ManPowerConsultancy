using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Command.Create
{
    public class CreateBodyMeasCmdHandler : IRequestHandler<CreateBodyMeasCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IBodyMeasurementRepository _bodyMeasurementRepository;

        public CreateBodyMeasCmdHandler(IMapper mapper, IBodyMeasurementRepository bodyMeasurementRepository)
        {
            _mapper = mapper;
            _bodyMeasurementRepository = bodyMeasurementRepository;
        }

        public async Task<Guid> Handle(CreateBodyMeasCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateBodyMeasCmdValidator(_bodyMeasurementRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid body measurement record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.BodyMeasurement>(request);
            recordToCreate.IsActive = true;
            // add to database
            await _bodyMeasurementRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
