using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Gender.Command.Update
{
    public class UpdateGenderCmdHandler : IRequestHandler<UpdateGenderCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        private readonly IAppLogger<UpdateGenderCmdHandler> _logger;

        public UpdateGenderCmdHandler(IMapper mapper, IGenderRepository genderRepository, IAppLogger<UpdateGenderCmdHandler> logger)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateGenderCmd request, CancellationToken cancellationToken)
        {
            var genderUpdateRequest = await _genderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (genderUpdateRequest is null)
                throw new NotFoundException(nameof(genderUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateGenderCmdValidator(_genderRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Gender), request.Id);
                throw new BadRequestException("Invalid gender", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, genderUpdateRequest);

            // add to database
            await _genderRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
