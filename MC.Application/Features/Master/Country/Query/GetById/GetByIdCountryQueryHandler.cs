using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Country.Query.GetById
{
    public class GetByIdCountryQueryHandler : IRequestHandler<GetByIdCountryQuery, CountryDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public GetByIdCountryQueryHandler(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<CountryDetailDto> Handle(GetByIdCountryQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _countryRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(Country), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<CountryDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
