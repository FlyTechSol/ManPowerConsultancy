using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Asset.Query.GetAll
{
    public class GetAllAssetQuery : IRequest<ApiResponse<PaginatedResponse<AssetDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllAssetQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
