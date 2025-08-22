using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.HighestEducation.Query.GetAll
{
    public class GetAllHighestEducationQueryHandler : IRequestHandler<GetAllHighestEducationQuery, List<HighestEducationDto>>
    {
        private readonly IMapper _mapper;
        private readonly IHighestEducationRepository _highestEducationRepository;
        private readonly IAppLogger<GetAllHighestEducationQueryHandler> _logger;

        public GetAllHighestEducationQueryHandler(IMapper mapper,
            IHighestEducationRepository highestEducationRepository,
            IAppLogger<GetAllHighestEducationQueryHandler> logger)
        {
            _mapper = mapper;
            _highestEducationRepository = highestEducationRepository;
            _logger = logger;
        }

        public async Task<List<HighestEducationDto>> Handle(GetAllHighestEducationQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _highestEducationRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<HighestEducationDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Highest education were retrieved successfully");
            return data;
        }
    }
}
