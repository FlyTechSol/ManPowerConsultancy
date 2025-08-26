using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetActiveRecordByregistrationId
{
    public record GetActiveRecordByregistrationIdQuery(int RegistrationId) : IRequest<BankAccountDetailDto>;
}
