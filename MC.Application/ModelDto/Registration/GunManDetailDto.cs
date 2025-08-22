using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Application.ModelDto.Registration
{
    public class GunManDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
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
        public bool IsActive { get; set; }
    }
}
