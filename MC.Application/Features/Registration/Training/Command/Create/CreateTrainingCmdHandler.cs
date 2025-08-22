using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Training.Command.Create
{
    public class CreateTrainingCmdHandler : IRequestHandler<CreateTrainingCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _trainingRepository;

        public CreateTrainingCmdHandler(IMapper mapper, ITrainingRepository trainingRepository)
        {
            _mapper = mapper;
            _trainingRepository = trainingRepository;
        }

        public async Task<Guid> Handle(CreateTrainingCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateTrainingCmdValidator(_trainingRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid training record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.Training>(request);

            // add to database
            await _trainingRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
