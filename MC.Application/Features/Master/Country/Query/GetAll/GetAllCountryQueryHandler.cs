using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Country.Query.GetAll
{
    public class GetAllCountryQueryHandler : IRequestHandler<GetAllCountryQuery, ApiResponse<PaginatedResponse<CountryDetailDto>>>
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

        public async Task<ApiResponse<PaginatedResponse<CountryDetailDto>>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _countryRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);
            return new ApiResponse<PaginatedResponse<CountryDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
