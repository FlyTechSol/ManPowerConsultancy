using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Command.Create
{
    public class CreateEmpRefCmdHandler : IRequestHandler<CreateEmpRefCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeReferenceRepository _employeeReferenceRepository;

        public CreateEmpRefCmdHandler(IMapper mapper, IEmployeeReferenceRepository employeeReferenceRepository)
        {
            _mapper = mapper;
            _employeeReferenceRepository = employeeReferenceRepository;
        }

        public async Task<Guid> Handle(CreateEmpRefCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateEmpRefCmdValidator(_employeeReferenceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid emp ref record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.EmployeeReference>(request);

            // add to database
            await _employeeReferenceRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
