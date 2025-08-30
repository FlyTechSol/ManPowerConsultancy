using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.ZipCode.Query.GetAll
{
    public class GetAllZipCodeQuery : IRequest<ApiResponse<PaginatedResponse<ZipCodeDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllZipCodeQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
