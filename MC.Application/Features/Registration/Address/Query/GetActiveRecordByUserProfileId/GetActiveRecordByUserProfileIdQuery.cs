using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Address.Query.GetActiveRecordByUserProfileId
{
   public record GetActiveRecordByUserProfileIdQuery(Guid UserProfileId) : IRequest<AddressDetailDto>;
}
