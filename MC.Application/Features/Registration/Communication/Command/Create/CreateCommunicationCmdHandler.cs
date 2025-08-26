using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Communication.Command.Create
{
    public class CreateCommunicationCmdHandler : IRequestHandler<CreateCommunicationCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICommunicationRepository _communicationRepository;

        public CreateCommunicationCmdHandler(IMapper mapper, ICommunicationRepository communicationRepository)
        {
            _mapper = mapper;
            _communicationRepository = communicationRepository;
        }

        public async Task<Guid> Handle(CreateCommunicationCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateCommunicationCmdValidator(_communicationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid communication record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.Communication>(request);
            recordToCreate.IsActive = true;
            // add to database
            await _communicationRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
