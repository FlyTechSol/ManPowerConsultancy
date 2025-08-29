using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Address.Query.GetActiveRecordByregistrationId
{
   public record GetActiveRecordByregistrationIdQuery(string RegistrationId) : IRequest<AddressDetailDto>;
}
