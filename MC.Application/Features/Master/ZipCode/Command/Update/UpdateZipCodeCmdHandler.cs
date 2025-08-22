using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.ZipCode.Command.Update
{
    public class UpdateZipCodeCmdHandler : IRequestHandler<UpdateZipCodeCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly IAppLogger<UpdateZipCodeCmdHandler> _logger;

        public UpdateZipCodeCmdHandler(IMapper mapper, IZipCodeRepository zipCodeRepository, IAppLogger<UpdateZipCodeCmdHandler> logger)
        {
            _mapper = mapper;
            _zipCodeRepository = zipCodeRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateZipCodeCmd request, CancellationToken cancellationToken)
        {
            var locationUpdateRequest = await _zipCodeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (locationUpdateRequest is null)
                throw new NotFoundException(nameof(locationUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateZipCodeCmdValidator(_zipCodeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(ZipCode), request.Id);
                throw new BadRequestException("Invalid zip code", validationResult);
            }

            // convert to domain entity object
            var locationToUpdate = _mapper.Map(request, locationUpdateRequest);

            // add to database
            await _zipCodeRepository.UpdateAsync(locationToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
