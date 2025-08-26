using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.SecurityDeposit.Command.Create
{
   public class CreateSecurityDepositCmdHandler : IRequestHandler<CreateSecurityDepositCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ISecurityDepositRepository _securityDepositRepository;

        public CreateSecurityDepositCmdHandler(IMapper mapper, ISecurityDepositRepository securityDepositRepository)
        {
            _mapper = mapper;
            _securityDepositRepository = securityDepositRepository;
        }

        public async Task<Guid> Handle(CreateSecurityDepositCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateSecurityDepositCmdValidator(_securityDepositRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid security deposit record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.SecurityDeposit>(request);
            recordToCreate.IsActive = true;
            // add to database
            await _securityDepositRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
