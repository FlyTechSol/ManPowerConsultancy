using MC.Application.Model.Identity.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Common.Identity.GetRegsiteredUser.Query
{
    public class GetAllRegisteredApprovedUsersQuery : IRequest<ApiResponse<PaginatedResponse<RegsiteredApprovedUserDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllRegisteredApprovedUsersQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
