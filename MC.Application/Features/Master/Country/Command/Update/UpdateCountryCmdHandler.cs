using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Country.Command.Update
{
    public class UpdateCountryCmdHandler : IRequestHandler<UpdateCountryCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly IAppLogger<UpdateCountryCmdHandler> _logger;

        public UpdateCountryCmdHandler(IMapper mapper, ICountryRepository countryRepository, IAppLogger<UpdateCountryCmdHandler> logger)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCountryCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _countryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateCountryCmdValidator(_countryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Country), request.Id);
                throw new BadRequestException("Invalid country type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _countryRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
