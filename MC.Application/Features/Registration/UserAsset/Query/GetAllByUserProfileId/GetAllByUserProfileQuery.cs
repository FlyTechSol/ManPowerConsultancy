using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Query.GetAllByUserProfileId
{
     public record GetAllByUserProfileQuery(Guid UserProfileId) : IRequest<List<UserAssetDetailDto>>;
}
