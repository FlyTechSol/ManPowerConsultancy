using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Command.Update
{
    public class UpdateInsNomineeCmdHandler : IRequestHandler<UpdateInsNomineeCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceNomineeRepository _insuranceNomineeRepository;
        private readonly IAppLogger<UpdateInsNomineeCmdHandler> _logger;

        public UpdateInsNomineeCmdHandler(IMapper mapper, IInsuranceNomineeRepository insuranceNomineeRepository, IAppLogger<UpdateInsNomineeCmdHandler> logger)
        {
            _mapper = mapper;
            _insuranceNomineeRepository = insuranceNomineeRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateInsNomineeCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _insuranceNomineeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateInsNomineeCmdValidator(_insuranceNomineeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.InsuranceNominee), request.Id);
                throw new BadRequestException("Invalid ins nominee detail", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _insuranceNomineeRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
