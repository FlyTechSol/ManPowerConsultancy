using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Asset.Query.GetAll
{
    public record GetAllAssetQuery : IRequest<List<AssetDto>>;
}
