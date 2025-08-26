using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.SecurityDeposit.Command.Update
{
   public class UpdateSecurityDepositCmdHandler : IRequestHandler<UpdateSecurityDepositCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ISecurityDepositRepository _securityDepositRepository;
        private readonly IAppLogger<UpdateSecurityDepositCmdHandler> _logger;

        public UpdateSecurityDepositCmdHandler(IMapper mapper, ISecurityDepositRepository securityDepositRepository, IAppLogger<UpdateSecurityDepositCmdHandler> logger)
        {
            _mapper = mapper;
            _securityDepositRepository = securityDepositRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateSecurityDepositCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _securityDepositRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateSecurityDepositCmdValidator(_securityDepositRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.SecurityDeposit), request.Id);
                throw new BadRequestException("Invalid security deposit detail", validationResult);
            }
            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _securityDepositRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
