using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Religion.Command.Update
{
   public class UpdateReligionCmdHandler : IRequestHandler<UpdateReligionCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IReligionRepository _religionRepository;
        private readonly IAppLogger<UpdateReligionCmdHandler> _logger;

        public UpdateReligionCmdHandler(IMapper mapper, IReligionRepository religionRepository, IAppLogger<UpdateReligionCmdHandler> logger)
        {
            _mapper = mapper;
            _religionRepository = religionRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateReligionCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _religionRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateReligionCmdValidator(_religionRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Asset), request.Id);
                throw new BadRequestException("Invalid asset type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _religionRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
