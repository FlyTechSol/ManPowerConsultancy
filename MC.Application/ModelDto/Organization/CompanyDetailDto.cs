using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Organization
{
    public class CompanyDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
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
    }
}
