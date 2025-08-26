using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Master.Master
{
    public class DocumentDetailDto :AuditableDto
    {
        public Guid Id { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsIdentityProof { get; set; } = false; // Indicates if the document is an identity proof
        public bool IsAddressProof { get; set; } = false; // Indicates if the document is an address proof
        public bool IsAgeProof { get; set; } = false; // Indicates if the document is an age proof
        public bool IsQualificationProof { get; set; } = false; // Indicates if the document is a qualification proof  
        public bool IsActive { get; set; } = true; // Indicates if the document is active
    }
}
