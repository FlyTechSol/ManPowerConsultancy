using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Designation.Command.Update
{
    public class UpdateDesignationCmdHandler : IRequestHandler<UpdateDesignationCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IDesignationRepository _designationRepository;
        private readonly IAppLogger<UpdateDesignationCmdHandler> _logger;

        public UpdateDesignationCmdHandler(IMapper mapper, IDesignationRepository designationRepository, IAppLogger<UpdateDesignationCmdHandler> logger)
        {
            _mapper = mapper;
            _designationRepository = designationRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateDesignationCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _designationRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateDesignationCmdValidator(_designationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Designation), request.Id);
                throw new BadRequestException("Invalid designation type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _designationRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
