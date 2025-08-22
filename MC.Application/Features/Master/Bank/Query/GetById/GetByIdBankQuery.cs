using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Bank.Query.GetById
{
    public record GetByIdBankQuery(Guid Id) : IRequest<BankDetailDto>;
}
