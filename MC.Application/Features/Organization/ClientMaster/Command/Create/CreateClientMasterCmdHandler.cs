using AutoMapper;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Command.Create
{
    public class CreateClientMasterCmdHandler : IRequestHandler<CreateClientMasterCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IClientMasterRepository _clientMasterRepository;

        public CreateClientMasterCmdHandler(IMapper mapper, IClientMasterRepository clientMasterRepository)
        {
            _mapper = mapper;
            _clientMasterRepository = clientMasterRepository;
        }

        public async Task<Guid> Handle(CreateClientMasterCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateClientMasterCmdValidator(_clientMasterRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid client master type", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Organization.ClientMaster>(request);

            await _clientMasterRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
