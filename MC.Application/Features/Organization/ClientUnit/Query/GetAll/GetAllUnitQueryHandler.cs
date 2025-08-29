using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Query.GetAll
{
    public class GetAllUnitQueryHandler : IRequestHandler<GetAllUnitQuery, List<UnitDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitRepository _unitRepository;
        private readonly IAppLogger<GetAllUnitQueryHandler> _logger;

        public GetAllUnitQueryHandler(IMapper mapper,
            IUnitRepository unitRepository,
            IAppLogger<GetAllUnitQueryHandler> logger)
        {
            _mapper = mapper;
            _unitRepository = unitRepository;
            _logger = logger;
        }

        public async Task<List<UnitDetailDto>> Handle(GetAllUnitQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _unitRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<UnitDetailDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Client unit were retrieved successfully");
            return data;
        }
    }
}
