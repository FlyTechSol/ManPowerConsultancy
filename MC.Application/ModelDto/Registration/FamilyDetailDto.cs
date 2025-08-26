using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Application.ModelDto.Registration
{
    public class FamilyDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Relationship Relationship { get; set; }
        public bool IsPFNominee { get; set; } = false;
        public double? PFPercentage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? RelationTo { get; set; }
        public bool IsMinor { get; set; } = false;
        public bool IsDependent { get; set; } = false;
        public bool IsResidingWithEmployee { get; set; } = false;
        public bool IsActive { get; set; }
    }
}
