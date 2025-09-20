using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeVerification.Command.Update
{
    public class UpdateEmployeeVerificationCmdHandler : IRequestHandler<UpdateEmployeeVerificationCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeVerificationRepository _employeeVerificationRepository;
        public UpdateEmployeeVerificationCmdHandler(IMapper mapper, IEmployeeVerificationRepository employeeVerificationRepository)
        {
            _mapper = mapper;
            _employeeVerificationRepository = employeeVerificationRepository;
        }

        public async Task<Unit> Handle(UpdateEmployeeVerificationCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _employeeVerificationRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateEmployeeVerificationCmdValidator(_employeeVerificationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid employee verification detail", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _employeeVerificationRepository.UpdateEmployeeVerificationAsync(recordToUpdate, request.AgencyReportUrl, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
