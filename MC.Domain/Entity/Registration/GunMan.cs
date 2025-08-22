using MC.Domain.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Domain.Entity.Registration
{
    public class GunMan : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string? GunLicenceName { get; set; }
        public string? GunLicenseNumber { get; set; }
        public string? WeaponNumber { get; set; }
        public WeaponType WeaponType { get; set; }
        public string? MakeOfCompany { get; set; }
        public string? GunLicenseIssuedBy { get; set; }
        public DateTime? GunLicenseIssuedDate { get; set; }
        public DateTime? GunLicenseExpiryDate { get; set; }
        public string? GunLicenseRemarks { get; set; }
        public string? Jurisdiction { get; set; }
        public string? LicenceAddress { get; set; }
        public bool IsActive { get; set; } = true; // Indicates if the reference is active
    }
}
