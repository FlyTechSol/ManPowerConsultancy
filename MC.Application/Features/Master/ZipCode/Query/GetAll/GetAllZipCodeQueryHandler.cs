using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.ZipCode.Query.GetAll
{
    public class GetAllZipCodeQueryHandler : IRequestHandler<GetAllZipCodeQuery, List<ZipCodeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly IAppLogger<GetAllZipCodeQueryHandler> _logger;

        public GetAllZipCodeQueryHandler(IMapper mapper,
            IZipCodeRepository zipCodeRepository,
            IAppLogger<GetAllZipCodeQueryHandler> logger)
        {
            _mapper = mapper;
            _zipCodeRepository = zipCodeRepository;
            _logger = logger;
        }

        public async Task<List<ZipCodeDto>> Handle(GetAllZipCodeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _zipCodeRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<ZipCodeDto>>(response);

            // return list of DTO object
            _logger.LogInformation("zip code were retrieved successfully");
            return data;
        }
    }
}
