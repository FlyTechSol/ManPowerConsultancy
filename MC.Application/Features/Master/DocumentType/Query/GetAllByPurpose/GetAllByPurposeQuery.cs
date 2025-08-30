using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Enum.Common;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Query.GetAllByPurpose
{
    public class GetAllByPurposeQuery : IRequest<ApiResponse<PaginatedResponse<DocumentTypeDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }
        public DocumentPurpose Purpose { get; set; }

        public GetAllByPurposeQuery(QueryParams queryParams, DocumentPurpose purpose)
        {
            QueryParams = queryParams;
            Purpose = purpose;
        }
    }
}
