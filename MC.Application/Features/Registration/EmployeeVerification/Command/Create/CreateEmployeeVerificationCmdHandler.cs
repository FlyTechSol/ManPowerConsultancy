using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeVerification.Command.Create
{
    public class CreateEmployeeVerificationCmdHandler : IRequestHandler<CreateEmployeeVerificationCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeVerificationRepository _employeeVerificationRepository;

        public CreateEmployeeVerificationCmdHandler(IMapper mapper, IEmployeeVerificationRepository employeeVerificationRepository)
        {
            _mapper = mapper;
            _employeeVerificationRepository = employeeVerificationRepository;
        }

        public async Task<Guid> Handle(CreateEmployeeVerificationCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateEmployeeVerificationCmdValidator(_employeeVerificationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid employee verification record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.EmployeeVerification>(request);

            // add to database
            await _employeeVerificationRepository.CreateEmployeeVerificationAsync(recordToCreate, null, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
