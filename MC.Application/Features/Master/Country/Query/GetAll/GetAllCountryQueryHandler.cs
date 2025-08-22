using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Country.Query.GetAll
{
   public class GetAllCountryQueryHandler : IRequestHandler<GetAllCountryQuery, List<CountryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly IAppLogger<GetAllCountryQueryHandler> _logger;

        public GetAllCountryQueryHandler(IMapper mapper,
            ICountryRepository countryRepository,
            IAppLogger<GetAllCountryQueryHandler> logger)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task<List<CountryDto>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _countryRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<CountryDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Country were retrieved successfully");
            return data;
        }
    }
}
