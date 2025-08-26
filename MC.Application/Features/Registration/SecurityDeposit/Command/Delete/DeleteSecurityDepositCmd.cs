using MediatR;

namespace MC.Application.Features.Registration.SecurityDeposit.Command.Delete
{
    public class DeleteSecurityDepositCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
