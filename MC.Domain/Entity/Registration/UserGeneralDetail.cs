using MC.Domain.Base;
using MC.Domain.Entity.Enum.Registration;
using MC.Domain.Entity.Master;

namespace MC.Domain.Entity.Registration
{
    public class UserGeneralDetail : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? SpouseName { get; set; }
        public Guid? ReligionId { get; set; }
        public Religion? Religion { get; set; }
        public Guid? CountryId { get; set; }
        public Country? Nationality { get; set; }
        public Guid? CasteCategoryId { get; set; }
        public CasteCategory? CasteCategory { get; set; }
        public bool DifferentlyAbled { get; set; } = false;
        public Guid? HighestEducationId { get; set; }
        public HighestEducation? HighestEducation { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }  // ✅ Spelling corrected from "MaritialStatus"
        public string? IdentityMarks { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
