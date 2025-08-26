using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Insurance.Command.Update
{
    public class UpdateInsuranceCmdHandler : IRequestHandler<UpdateInsuranceCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly IAppLogger<UpdateInsuranceCmdHandler> _logger;

        public UpdateInsuranceCmdHandler(IMapper mapper, IInsuranceRepository insuranceRepository, IAppLogger<UpdateInsuranceCmdHandler> logger)
        {
            _mapper = mapper;
            _insuranceRepository = insuranceRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateInsuranceCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _insuranceRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateInsuranceCmdValidator(_insuranceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.Insurance), request.Id);
                throw new BadRequestException("Invalid insurance detail", validationResult);
            }
            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _insuranceRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
