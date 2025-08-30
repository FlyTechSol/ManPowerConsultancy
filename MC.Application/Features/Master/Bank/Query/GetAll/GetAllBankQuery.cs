using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Bank.Query.GetAll
{
    public class GetAllBankQuery : IRequest<ApiResponse<PaginatedResponse<BankDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllBankQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
