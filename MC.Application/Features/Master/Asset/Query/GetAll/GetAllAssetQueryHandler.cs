using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Asset.Query.GetAll
{
    public class GetAllAssetQueryHandler : IRequestHandler<GetAllAssetQuery, List<AssetDto>>
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

        public async Task<List<AssetDto>> Handle(GetAllAssetQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _assetRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<AssetDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Asset were retrieved successfully");
            return data;
        }
    }
}
