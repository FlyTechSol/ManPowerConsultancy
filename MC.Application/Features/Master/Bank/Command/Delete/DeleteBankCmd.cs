using MediatR;

namespace MC.Application.Features.Master.Bank.Command.Delete
{
    public class DeleteBankCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
