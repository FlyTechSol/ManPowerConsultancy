using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.HighestEducation.Command.Update
{
    public class UpdateHighestEducationCmdHandler : IRequestHandler<UpdateHighestEducationCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IHighestEducationRepository _highestEducationRepository;
        private readonly IAppLogger<UpdateHighestEducationCmdHandler> _logger;

        public UpdateHighestEducationCmdHandler(IMapper mapper, IHighestEducationRepository highestEducationRepository, IAppLogger<UpdateHighestEducationCmdHandler> logger)
        {
            _mapper = mapper;
            _highestEducationRepository = highestEducationRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateHighestEducationCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _highestEducationRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateHighestEducationCmdValidator(_highestEducationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(HighestEducation), request.Id);
                throw new BadRequestException("Invalid higest education type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _highestEducationRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
