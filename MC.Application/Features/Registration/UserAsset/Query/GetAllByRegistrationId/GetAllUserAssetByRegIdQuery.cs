using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Query.GetAllByRegistrationId
{
    public record GetAllUserAssetByRegIdQuery(string RegistrationId) : IRequest<UserAssetDetailDto>;
}
