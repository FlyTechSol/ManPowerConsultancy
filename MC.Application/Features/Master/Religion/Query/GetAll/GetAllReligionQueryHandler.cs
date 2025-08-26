using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Religion.Query.GetAll
{
    public class GetAllReligionQueryHandler : IRequestHandler<GetAllReligionQuery, List<ReligionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReligionRepository _religionRepository;
        private readonly IAppLogger<GetAllReligionQueryHandler> _logger;

        public GetAllReligionQueryHandler(IMapper mapper,
            IReligionRepository religionRepository,
            IAppLogger<GetAllReligionQueryHandler> logger)
        {
            _mapper = mapper;
            _religionRepository = religionRepository;
            _logger = logger;
        }

        public async Task<List<ReligionDto>> Handle(GetAllReligionQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _religionRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<ReligionDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Asset were retrieved successfully");
            return data;
        }
    }
}
