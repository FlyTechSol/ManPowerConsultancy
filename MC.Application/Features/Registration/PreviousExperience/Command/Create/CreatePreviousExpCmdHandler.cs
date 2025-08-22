using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Command.Create
{
    public class CreatePreviousExpCmdHandler : IRequestHandler<CreatePreviousExpCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IPreviousExperienceRepository _previousExperienceRepository;

        public CreatePreviousExpCmdHandler(IMapper mapper, IPreviousExperienceRepository previousExperienceRepository)
        {
            _mapper = mapper;
            _previousExperienceRepository = previousExperienceRepository;
        }

        public async Task<Guid> Handle(CreatePreviousExpCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreatePreviousExpCmdValidator(_previousExperienceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid pre exp record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.PreviousExperience>(request);

            // add to database
            await _previousExperienceRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
