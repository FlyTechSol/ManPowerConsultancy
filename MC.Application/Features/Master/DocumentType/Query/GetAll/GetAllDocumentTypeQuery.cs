using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Query.GetAll
{
    public class GetAllDocumentTypeQuery : IRequest<ApiResponse<PaginatedResponse<DocumentTypeDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllDocumentTypeQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
