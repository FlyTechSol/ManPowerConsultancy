using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Query.GetAll
{
    public class GetAllUnitQueryHandler : IRequestHandler<GetAllUnitQuery, ApiResponse<PaginatedResponse<UnitDetailDto>>>
    {
        private readonly IUnitRepository _unitRepository;
      
        public GetAllUnitQueryHandler(
            IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public async Task<ApiResponse<PaginatedResponse<UnitDetailDto>>> Handle(GetAllUnitQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _unitRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);
            return new ApiResponse<PaginatedResponse<UnitDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
