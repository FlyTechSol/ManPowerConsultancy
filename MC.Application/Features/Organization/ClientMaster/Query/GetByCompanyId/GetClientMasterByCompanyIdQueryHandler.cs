using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Query.GetByCompanyId
{
    public class GetClientMasterByCompanyIdQueryHandler : IRequestHandler<GetClientMasterByCompanyIdQuery, List<ClientMasterDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IClientMasterRepository _clientMasterRepository;
        private readonly IAppLogger<GetClientMasterByCompanyIdQueryHandler> _logger;

        public GetClientMasterByCompanyIdQueryHandler(IMapper mapper,
            IClientMasterRepository clientMasterRepository,
            IAppLogger<GetClientMasterByCompanyIdQueryHandler> logger)
        {
            _mapper = mapper;
            _clientMasterRepository = clientMasterRepository;
            _logger = logger;
        }

        public async Task<List<ClientMasterDetailDto>> Handle(GetClientMasterByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _clientMasterRepository.GetClientMasterByCompanyIdAsync(request.CompanyId, cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<ClientMasterDetailDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Client master were retrieved successfully");
            return data;
        }
    }
}
