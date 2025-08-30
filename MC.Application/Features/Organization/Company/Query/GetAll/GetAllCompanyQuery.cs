using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.Company.Query.GetAll
{
    public class GetAllCompanyQuery : IRequest<ApiResponse<PaginatedResponse<CompanyDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllCompanyQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
