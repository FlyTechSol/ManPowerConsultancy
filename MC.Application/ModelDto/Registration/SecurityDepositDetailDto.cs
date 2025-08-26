using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Registration
{
    public class SecurityDepositDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public string ReciptNumber { get; set; } = string.Empty;
        public double Amount { get; set; }
        public double RefundableAmount { get; set; }
        public double NonRefundableAmount { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string? Remark { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
