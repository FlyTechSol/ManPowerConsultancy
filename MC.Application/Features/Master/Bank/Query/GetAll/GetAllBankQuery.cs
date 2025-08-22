using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Bank.Query.GetAll
{
   public record GetAllBankQuery : IRequest<List<BankDto>>;
}
