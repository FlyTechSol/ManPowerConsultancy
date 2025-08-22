using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Command.Update
{
    public class UpdateUserAssetCmdHandler : IRequestHandler<UpdateUserAssetCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUserAssetRepository _userAssetRepository;
        private readonly IAppLogger<UpdateUserAssetCmdHandler> _logger;

        public UpdateUserAssetCmdHandler(IMapper mapper, IUserAssetRepository userAssetRepository, IAppLogger<UpdateUserAssetCmdHandler> logger)
        {
            _mapper = mapper;
            _userAssetRepository = userAssetRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateUserAssetCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _userAssetRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateUserAssetCmdValidator(_userAssetRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.UserAsset), request.Id);
                throw new BadRequestException("Invalid user asset detail", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _userAssetRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
