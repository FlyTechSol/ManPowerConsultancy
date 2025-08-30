using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Query.GetByClientMasterId
{
    public class GetUnitByClientMasterQueryHandler : IRequestHandler<GetUnitByClientMasterQuery, ApiResponse<PaginatedResponse<UnitDetailDto>>>
    {
        private readonly IUnitRepository _unitRepository;

        public GetUnitByClientMasterQueryHandler(
            IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<UnitDetailDto>>> Handle(GetUnitByClientMasterQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _unitRepository.GetUnitByClientMasterIdAsync(request.QueryParams, request.ClientMasterId, cancellationToken);
            return new ApiResponse<PaginatedResponse<UnitDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
