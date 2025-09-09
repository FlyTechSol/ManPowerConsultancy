using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Address.Query.GetAll
{
    public class GetAllAddressQuery : IRequest<ApiResponse<PaginatedResponse<AddressDetailDto>>>
    {
        public Guid UserProfileId { get; set; }
        public QueryParams QueryParams { get; set; }

        public GetAllAddressQuery(Guid userProfileId, QueryParams queryParams)
        {
            UserProfileId = userProfileId;
            QueryParams = queryParams;
        }
    }
}
