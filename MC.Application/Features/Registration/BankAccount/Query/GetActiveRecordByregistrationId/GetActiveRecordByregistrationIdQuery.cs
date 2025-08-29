using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetActiveRecordByregistrationId
{
    public record GetActiveRecordByregistrationIdQuery(string RegistrationId) : IRequest<BankAccountDetailDto>;
}
