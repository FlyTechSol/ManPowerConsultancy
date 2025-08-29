using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Command.Update
{
    public class UpdateUnitCmdHandler : IRequestHandler<UpdateUnitCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitRepository _unitRepository;
        private readonly IAppLogger<UpdateUnitCmdHandler> _logger;

        public UpdateUnitCmdHandler(IMapper mapper, IUnitRepository unitRepository, IAppLogger<UpdateUnitCmdHandler> logger)
        {
            _mapper = mapper;
            _unitRepository = unitRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateUnitCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _unitRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateUnitCmdValidator(_unitRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(ClientUnit), request.Id);
                throw new BadRequestException("Invalid client unit type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _unitRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
