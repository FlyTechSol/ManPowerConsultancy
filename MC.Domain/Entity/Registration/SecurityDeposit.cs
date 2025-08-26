using MC.Domain.Base;

namespace MC.Domain.Entity.Registration
{
    public class SecurityDeposit : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string ReciptNumber { get; set; } = string.Empty;
        public double Amount { get; set; }
        public double RefundableAmount { get; set; }
        public double NonRefundableAmount { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string? Remark { get; set; } 
        public bool IsActive { get; set; } = true;
    }
}
