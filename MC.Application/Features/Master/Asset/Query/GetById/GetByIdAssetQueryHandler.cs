using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Asset.Query.GetById
{
    public class GetByIdAssetQueryHandler : IRequestHandler<GetByIdAssetQuery, AssetDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IAssetRepository _assetRepository;

        public GetByIdAssetQueryHandler(IMapper mapper, IAssetRepository assetRepository)
        {
            _mapper = mapper;
            _assetRepository = assetRepository;
        }

        public async Task<AssetDetailDto> Handle(GetByIdAssetQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _assetRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(Asset), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<AssetDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
