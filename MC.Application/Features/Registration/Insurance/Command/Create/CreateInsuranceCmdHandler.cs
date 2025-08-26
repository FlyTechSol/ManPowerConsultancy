using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Insurance.Command.Create
{
    public class CreateInsuranceCmdHandler : IRequestHandler<CreateInsuranceCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceRepository _insuranceRepository;

        public CreateInsuranceCmdHandler(IMapper mapper, IInsuranceRepository insuranceRepository)
        {
            _mapper = mapper;
            _insuranceRepository = insuranceRepository;
        }

        public async Task<Guid> Handle(CreateInsuranceCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateInsuranceCmdValidator(_insuranceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid insurance record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.Insurance>(request);
            recordToCreate.IsActive = true;
            // add to database
            await _insuranceRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
