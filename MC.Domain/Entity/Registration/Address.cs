using MC.Domain.Base;
using MC.Domain.Entity.Enum.Registration;
using MC.Domain.Entity.Identity;

namespace MC.Domain.Entity.Registration
{
    public class Address : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public AddressType AddressType { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
