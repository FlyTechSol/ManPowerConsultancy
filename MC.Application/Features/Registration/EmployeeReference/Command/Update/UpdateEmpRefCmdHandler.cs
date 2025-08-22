using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Command.Update
{
    public class UpdateEmpRefCmdHandler : IRequestHandler<UpdateEmpRefCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeReferenceRepository _employeeReferenceRepository;
        private readonly IAppLogger<UpdateEmpRefCmdHandler> _logger;

        public UpdateEmpRefCmdHandler(IMapper mapper, IEmployeeReferenceRepository employeeReferenceRepository, IAppLogger<UpdateEmpRefCmdHandler> logger)
        {
            _mapper = mapper;
            _employeeReferenceRepository = employeeReferenceRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateEmpRefCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _employeeReferenceRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateEmpRefCmdValidator(_employeeReferenceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.EmployeeReference), request.Id);
                throw new BadRequestException("Invalid emp ref detail", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _employeeReferenceRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
