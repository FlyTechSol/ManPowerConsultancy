using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Application.ModelDto.Registration
{
    public class UserAssetDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public Guid AssetId { get; set; }
        public string AssetName { get; set; } = string.Empty; // Navigation property to Asset
        public DateTime DateOfIssue { get; set; }
        public string SerialNo { get; set; } = string.Empty;
        public decimal AssetValue { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; } = string.Empty; // Additional information about the asset
        public bool IsReturnable { get; set; } = true;
        public bool IsReturned { get; set; } = false;
        public DateTime? ReturnDate { get; set; }
        public ReturnAssetStatus ReturnStatus { get; set; }  // e.g., "Good", "Fair", "Bad"
        public bool IsActive { get; set; }
    }
}
