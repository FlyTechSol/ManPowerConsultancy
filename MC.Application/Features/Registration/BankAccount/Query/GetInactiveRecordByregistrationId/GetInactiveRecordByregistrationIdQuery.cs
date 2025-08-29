using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetInactiveRecordByregistrationId
{
    public record GetInactiveRecordByregistrationIdQuery(string RegistrationId) : IRequest<List<BankAccountDetailDto>>;
}
