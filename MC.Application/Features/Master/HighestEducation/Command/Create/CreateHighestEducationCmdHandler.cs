using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.HighestEducation.Command.Create
{
    public class CreateHighestEducationCmdHandler : IRequestHandler<CreateHighestEducationCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IHighestEducationRepository _highestEducationRepository;

        public CreateHighestEducationCmdHandler(IMapper mapper, IHighestEducationRepository highestEducationRepository)
        {
            _mapper = mapper;
            _highestEducationRepository = highestEducationRepository;
        }

        public async Task<Guid> Handle(CreateHighestEducationCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateHighestEducationCmdValidator(_highestEducationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid higest education type", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.HighestEducation>(request);

            await _highestEducationRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
