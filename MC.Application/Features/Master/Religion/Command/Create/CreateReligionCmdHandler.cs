using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Religion.Command.Create
{
    public class CreateReligionCmdHandler : IRequestHandler<CreateReligionCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IReligionRepository _religionRepository;

        public CreateReligionCmdHandler(IMapper mapper, IReligionRepository religionRepository)
        {
            _mapper = mapper;
            _religionRepository = religionRepository;
        }

        public async Task<Guid> Handle(CreateReligionCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateReligionCmdValidator(_religionRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid religion type", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.Religion>(request);

            await _religionRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
