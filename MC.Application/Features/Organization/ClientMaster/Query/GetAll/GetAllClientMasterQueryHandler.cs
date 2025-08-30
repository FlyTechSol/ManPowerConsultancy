using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Features.Master.Title.Query.GetAll;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Query.GetAll
{
    public class GetAllClientMasterQueryHandler : IRequestHandler<GetAllClientMasterQuery, ApiResponse<PaginatedResponse<ClientMasterDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IClientMasterRepository _clientMasterRepository;
        private readonly IAppLogger<GetAllClientMasterQueryHandler> _logger;

        public GetAllClientMasterQueryHandler(IMapper mapper,
            IClientMasterRepository clientMasterRepository,
            IAppLogger<GetAllClientMasterQueryHandler> logger)
        {
            _mapper = mapper;
            _clientMasterRepository = clientMasterRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<PaginatedResponse<ClientMasterDetailDto>>> Handle(GetAllClientMasterQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _clientMasterRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);
            return new ApiResponse<PaginatedResponse<ClientMasterDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
