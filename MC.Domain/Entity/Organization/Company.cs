using MC.Domain.Base;
using MC.Domain.Entity.Registration;

namespace MC.Domain.Entity.Organization
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; } = null!;
        public string? LegalName { get; set; } // Optional legal name
        public string? RegistrationNumber { get; set; } // GSTIN or Corp ID
        public string? CompanyPan { get; set; } // Company PAN
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }

        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
        public ICollection<ClientMaster> ClientMasters { get; set; } = new List<ClientMaster>();
        public RegistrationSequence RegistrationSequence { get; set; } = null!;
    }

}
