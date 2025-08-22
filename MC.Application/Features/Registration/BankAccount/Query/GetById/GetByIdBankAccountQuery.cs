using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetById
{
    public record GetByIdBankAccountQuery(Guid Id) : IRequest<BankAccountDto>;
}
