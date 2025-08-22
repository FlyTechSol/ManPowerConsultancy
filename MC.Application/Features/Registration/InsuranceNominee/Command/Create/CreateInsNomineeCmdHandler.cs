using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Command.Create
{
    public class CreateInsNomineeCmdHandler : IRequestHandler<CreateInsNomineeCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceNomineeRepository _insuranceNomineeRepository;

        public CreateInsNomineeCmdHandler(IMapper mapper, IInsuranceNomineeRepository insuranceNomineeRepository)
        {
            _mapper = mapper;
            _insuranceNomineeRepository = insuranceNomineeRepository;
        }

        public async Task<Guid> Handle(CreateInsNomineeCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateInsNomineeCmdValidator(_insuranceNomineeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid ins nominee record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.InsuranceNominee>(request);

            // add to database
            await _insuranceNomineeRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
