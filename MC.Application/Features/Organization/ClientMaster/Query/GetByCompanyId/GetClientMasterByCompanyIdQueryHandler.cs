using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Query.GetByCompanyId
{
    public class GetClientMasterByCompanyIdQueryHandler : IRequestHandler<GetClientMasterByCompanyIdQuery, ApiResponse<PaginatedResponse<ClientMasterDetailDto>>>
    {
        private readonly IClientMasterRepository _clientMasterRepository;
     
        public GetClientMasterByCompanyIdQueryHandler(
            IClientMasterRepository clientMasterRepository)
        {
            _clientMasterRepository = clientMasterRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<ClientMasterDetailDto>>> Handle(GetClientMasterByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _clientMasterRepository.GetClientMasterByCompanyIdAsync(request.QueryParams, request.CompanyId, cancellationToken);
            return new ApiResponse<PaginatedResponse<ClientMasterDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
