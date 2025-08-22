using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Command.Update
{
    public class UpdateExArmyCmdHandler : IRequestHandler<UpdateExArmyCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IExArmyRepository _exArmyRepository;
        private readonly IAppLogger<UpdateExArmyCmdHandler> _logger;

        public UpdateExArmyCmdHandler(IMapper mapper, IExArmyRepository exArmyRepository, IAppLogger<UpdateExArmyCmdHandler> logger)
        {
            _mapper = mapper;
            _exArmyRepository = exArmyRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateExArmyCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _exArmyRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateExArmyCmdValidator(_exArmyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.ExArmy), request.Id);
                throw new BadRequestException("Invalid ex army detail", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _exArmyRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
