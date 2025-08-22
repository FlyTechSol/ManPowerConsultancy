using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Address.Query.GetInactiveRecordByregistrationId
{
    public record GetInactiveRecordByregistrationIdQuery(string RegistrationId) : IRequest<AddressDetailDto>;
}
