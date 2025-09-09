using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Application.ModelDto.Registration
{
    public class AddressDetailDto :AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public AddressType AddressType { get; set; }
        public bool IsActive { get; set; }
    }
}
