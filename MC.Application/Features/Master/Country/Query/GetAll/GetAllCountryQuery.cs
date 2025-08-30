using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Country.Query.GetAll
{
    public class GetAllCountryQuery : IRequest<ApiResponse<PaginatedResponse<CountryDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllCountryQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
