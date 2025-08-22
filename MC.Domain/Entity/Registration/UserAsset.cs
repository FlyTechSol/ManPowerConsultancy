using MC.Domain.Base;
using MC.Domain.Entity.Enum.Registration;
using MC.Domain.Entity.Master;

namespace MC.Domain.Entity.Registration
{
    public class UserAsset : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers

        public Guid AssetId { get; set; }
        public required Asset Asset { get; set; } // Navigation property to Asset
        public DateTime DateOfIssue { get; set; }
        public string SerialNo { get; set; } = string.Empty;
        public decimal AssetValue { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; } = string.Empty; // Additional information about the asset
        public bool IsReturnable { get; set; } = true;
        public bool IsReturned { get; set; } = false;
        public DateTime? ReturnDate { get; set; }
        public ReturnAssetStatus ReturnStatus { get; set; }  // e.g., "Good", "Fair", "Bad"
        public bool IsActive { get; set; } = true; // Indicates if the reference is active
    }
}
