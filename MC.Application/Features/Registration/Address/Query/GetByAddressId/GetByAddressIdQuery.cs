using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Address.Query.GetByAddressId
{
   public record GetByAddressIdQuery(Guid Id) : IRequest<AddressDetailDto>;
}
