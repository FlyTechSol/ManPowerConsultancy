using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Title.Query.GetAll
{
    public class GetAllTitleQuery : IRequest<ApiResponse<PaginatedResponse<TitleDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }
        public bool? IsMale { get; set; }

        public GetAllTitleQuery(QueryParams queryParams, bool? isMale)
        {
            QueryParams = queryParams;
            IsMale = isMale;
        }
    }
}
