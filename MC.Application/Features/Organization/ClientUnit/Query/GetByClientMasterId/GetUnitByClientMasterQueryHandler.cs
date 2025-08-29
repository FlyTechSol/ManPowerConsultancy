using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Query.GetByClientMasterId
{
    public class GetUnitByClientMasterQueryHandler : IRequestHandler<GetUnitByClientMasterQuery, List<UnitDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitRepository _unitRepository;
        private readonly IAppLogger<GetUnitByClientMasterQueryHandler> _logger;

        public GetUnitByClientMasterQueryHandler(IMapper mapper,
            IUnitRepository unitRepository,
            IAppLogger<GetUnitByClientMasterQueryHandler> logger)
        {
            _mapper = mapper;
            _unitRepository = unitRepository;
            _logger = logger;
        }

        public async Task<List<UnitDetailDto>> Handle(GetUnitByClientMasterQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _unitRepository.GetUnitByClientMasterIdAsync(request.ClientMasterId, cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<UnitDetailDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Client unit were retrieved successfully");
            return data;
        }
    }
}
