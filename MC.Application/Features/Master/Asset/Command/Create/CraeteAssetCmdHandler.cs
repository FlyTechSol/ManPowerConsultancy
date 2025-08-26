using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Asset.Command.Create
{
    public class CraeteAssetCmdHandler : IRequestHandler<CraeteAssetCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAssetRepository _assetRepository;

        public CraeteAssetCmdHandler(IMapper mapper, IAssetRepository assetRepository)
        {
            _mapper = mapper;
            _assetRepository = assetRepository;
        }

        public async Task<Guid> Handle(CraeteAssetCmd request, CancellationToken cancellationToken)
        {
            var validator = new CraeteAssetCmdValidator(_assetRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid asset type", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.Asset>(request);

            await _assetRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
