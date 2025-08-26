using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Resignation.Command.Update
{
   public class UpdateResignationCmdHandler : IRequestHandler<UpdateResignationCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IResignationRepository _resignationRepository;
        private readonly IAppLogger<UpdateResignationCmdHandler> _logger;

        public UpdateResignationCmdHandler(IMapper mapper, IResignationRepository resignationRepository, IAppLogger<UpdateResignationCmdHandler> logger)
        {
            _mapper = mapper;
            _resignationRepository = resignationRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateResignationCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _resignationRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateResignationCmdValidator(_resignationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.Resignation), request.Id);
                throw new BadRequestException("Invalid resignation detail", validationResult);
            }
            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _resignationRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
