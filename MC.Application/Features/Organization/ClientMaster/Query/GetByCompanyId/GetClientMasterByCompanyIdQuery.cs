using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Query.GetByCompanyId
{
    public class GetClientMasterByCompanyIdQuery : IRequest<ApiResponse<PaginatedResponse<ClientMasterDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }
        public Guid CompanyId { get; set; }

        public GetClientMasterByCompanyIdQuery(QueryParams queryParams, Guid companyId)
        {
            QueryParams = queryParams;
            CompanyId = companyId;
        }
    }
}
