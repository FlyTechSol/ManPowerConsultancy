using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.SecurityDeposit.Command.Create
{
    public class CreateSecurityDepositCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public string ReciptNumber { get; set; } = string.Empty;
        public double Amount { get; set; }
        public double RefundableAmount { get; set; }
        public double NonRefundableAmount { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string? Remark { get; set; }
    }
}
