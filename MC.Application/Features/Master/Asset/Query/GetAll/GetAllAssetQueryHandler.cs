using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Asset.Query.GetAll
{
    public class GetAllAssetQueryHandler : IRequestHandler<GetAllAssetQuery, ApiResponse<PaginatedResponse<AssetDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IAssetRepository _assetRepository;
        private readonly IAppLogger<GetAllAssetQueryHandler> _logger;

        public GetAllAssetQueryHandler(IMapper mapper,
            IAssetRepository assetRepository,
            IAppLogger<GetAllAssetQueryHandler> logger)
        {
            _mapper = mapper;
            _assetRepository = assetRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<PaginatedResponse<AssetDetailDto>>> Handle(GetAllAssetQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _assetRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<AssetDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
