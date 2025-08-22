using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Query.GetById
{
    public record GetByIdUserAssetQuery(Guid Id) : IRequest<UserAssetDetailDto>;
}
