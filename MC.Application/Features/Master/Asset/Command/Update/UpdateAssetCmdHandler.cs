using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Asset.Command.Update
{
    public class UpdateAssetCmdHandler : IRequestHandler<UpdateAssetCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAssetRepository _assetRepository;
        private readonly IAppLogger<UpdateAssetCmdHandler> _logger;

        public UpdateAssetCmdHandler(IMapper mapper, IAssetRepository assetRepository, IAppLogger<UpdateAssetCmdHandler> logger)
        {
            _mapper = mapper;
            _assetRepository = assetRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateAssetCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _assetRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateAssetCmdValidator(_assetRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Asset), request.Id);
                throw new BadRequestException("Invalid asset type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _assetRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
