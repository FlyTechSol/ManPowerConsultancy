using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Registration;
using MC.Domain.Entity.Master;

namespace MC.Application.ModelDto.Registration
{
    public class UserGeneralDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? SpouseName { get; set; }
        public Guid? ReligionId { get; set; }
        public string? ReligionName { get; set; }
        public Guid? CountryId { get; set; }
        public string? Nationality { get; set; }
        public Guid? CasteCategoryId { get; set; }
        public string? CasteCategoryName { get; set; }
        public bool DifferentlyAbled { get; set; } = false;
        public Guid? HighestEducationId { get; set; }
        public string? HighestEducationName { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }  
        public string? IdentityMarks { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
