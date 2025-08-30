using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.RecruitmentType.Query.GetAll
{
    public class GetAllRecruitmentTypeQueryHandler : IRequestHandler<GetAllRecruitmentTypeQuery, ApiResponse<PaginatedResponse<RecruitmentTypeDetailDto>>>
    {
        private readonly IRecruitmentTypeRepository _recruitmentTypeRepository;
        private readonly IAppLogger<GetAllRecruitmentTypeQueryHandler> _logger;

        public GetAllRecruitmentTypeQueryHandler(
            IRecruitmentTypeRepository recruitmentTypeRepository,
            IAppLogger<GetAllRecruitmentTypeQueryHandler> logger)
        {
            _recruitmentTypeRepository = recruitmentTypeRepository;
            _logger = logger;
        }
        public async Task<ApiResponse<PaginatedResponse<RecruitmentTypeDetailDto>>> Handle(GetAllRecruitmentTypeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _recruitmentTypeRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);
            return new ApiResponse<PaginatedResponse<RecruitmentTypeDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
