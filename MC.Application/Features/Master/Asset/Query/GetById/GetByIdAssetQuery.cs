using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Asset.Query.GetById
{
   public record GetByIdAssetQuery(Guid Id) : IRequest<AssetDetailDto>;
}
