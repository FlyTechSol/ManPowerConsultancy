using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeVerification.Query.GetAll
{
    public class GetAllEmpVeriQuery : IRequest<ApiResponse<PaginatedResponse<EmployeeVerificationDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }
        public Guid UserProfileId { get; set; }

        public GetAllEmpVeriQuery(Guid userProfileId, QueryParams queryParams)
        {
            UserProfileId = userProfileId;
            QueryParams = queryParams;
        }
    }
}
