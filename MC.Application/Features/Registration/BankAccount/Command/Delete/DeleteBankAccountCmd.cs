using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Command.Delete
{
    public class DeleteBankAccountCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
