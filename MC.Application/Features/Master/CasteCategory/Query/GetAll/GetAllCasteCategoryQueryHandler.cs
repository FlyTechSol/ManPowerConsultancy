using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.CasteCategory.Query.GetAll
{
    public class GetAllCasteCategoryQueryHandler : IRequestHandler<GetAllCasteCategoryQuery, ApiResponse<PaginatedResponse<CasteCategoryDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ICasteCategoryRepository _casteCategoryRepository;
        private readonly IAppLogger<GetAllCasteCategoryQueryHandler> _logger;

        public GetAllCasteCategoryQueryHandler(IMapper mapper,
            ICasteCategoryRepository casteCategoryRepository,
            IAppLogger<GetAllCasteCategoryQueryHandler> logger)
        {
            _mapper = mapper;
            _casteCategoryRepository = casteCategoryRepository;
            _logger = logger;
        }
        public async Task<ApiResponse<PaginatedResponse<CasteCategoryDetailDto>>> Handle(GetAllCasteCategoryQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _casteCategoryRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<CasteCategoryDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
