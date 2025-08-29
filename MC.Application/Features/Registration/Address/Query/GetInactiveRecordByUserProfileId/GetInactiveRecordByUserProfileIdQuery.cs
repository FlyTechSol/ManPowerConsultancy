using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Address.Query.GetInactiveRecordByUserProfileId
{
     public record GetInactiveRecordByUserProfileIdQuery(Guid UseerProfileId) : IRequest<List<AddressDetailDto>>;
}
