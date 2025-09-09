using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Query.GetAll
{
    public class GetAllEmpRefQuery : IRequest<ApiResponse<PaginatedResponse<EmployeeReferenceDetailDto>>>
    {
        public Guid UserProfileId { get; set; }
        public QueryParams QueryParams { get; set; }

        public GetAllEmpRefQuery(Guid userProfileId, QueryParams queryParams)
        {
            UserProfileId = userProfileId;
            QueryParams = queryParams;
        }
    }
}
