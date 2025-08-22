using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.GunMan.Command.Create
{
    public class CreateGunManCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
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
