using MC.Domain.Base;

namespace MC.Domain.Entity.Master
{
    public class Document : BaseEntity
    {
        public string DocumentName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsIdentityProof { get; set; } = false; // Indicates if the document is an identity proof
        public bool IsAddressProof { get; set; } = false; // Indicates if the document is an address proof
        public bool IsAgeProof { get; set; } = false; // Indicates if the document is an age proof
        public bool IsQualificationProof { get; set; } = false; // Indicates if the document is a qualification proof  
    }
}
