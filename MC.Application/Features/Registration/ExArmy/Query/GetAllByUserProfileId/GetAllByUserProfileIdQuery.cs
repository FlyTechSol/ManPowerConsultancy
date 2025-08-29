using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Query.GetAllByUserProfileId
{
   public record GetAllByUserProfileIdQuery(Guid UserProfileId) : IRequest<ExArmyDetailDto>;
}
