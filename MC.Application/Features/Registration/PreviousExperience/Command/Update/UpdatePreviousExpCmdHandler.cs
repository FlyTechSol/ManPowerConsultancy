using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Command.Update
{
    public class UpdatePreviousExpCmdHandler : IRequestHandler<UpdatePreviousExpCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPreviousExperienceRepository _previousExperienceRepository;
        private readonly IAppLogger<UpdatePreviousExpCmdHandler> _logger;

        public UpdatePreviousExpCmdHandler(IMapper mapper, IPreviousExperienceRepository previousExperienceRepository, IAppLogger<UpdatePreviousExpCmdHandler> logger)
        {
            _mapper = mapper;
            _previousExperienceRepository = previousExperienceRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdatePreviousExpCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _previousExperienceRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdatePreviousExpCmdValidator(_previousExperienceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.PreviousExperience), request.Id);
                throw new BadRequestException("Invalid pre exp detail", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _previousExperienceRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
