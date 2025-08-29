using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Communication.Query.GetByUserProfileId
{
   public record GetByUserProfileIdQuery(Guid UserProfileId) : IRequest<CommunicationDetailDto>;
}
