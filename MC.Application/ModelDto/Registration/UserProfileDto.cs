using MC.Application.ModelDto.Base;
using Microsoft.AspNetCore.Http;

namespace MC.Application.ModelDto.Registration
{
    public class UserProfileDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; } // Nullable
        public string? User { get; set; } // Optional navigation
        public Guid? CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public Guid? ClientMasterId { get; set; }
        public string ClientMaster { get; set; } = null!;
        public Guid? ClientUnitId { get; set; }
        public string ClientUnit { get; set; } = null!;
        public Guid? BranchId { get; set; }
        public string Branch { get; set; } = null!;
        public Guid? DesignationId { get; set; }
        public string Designation { get; set; } = null!;
        public Guid? CategoryId { get; set; }
        public string Category { get; set; } = null!;
        public string RegistrationId { get; set; } = null!; // Unique, non-null
        public Guid? TitleId { get; set; }
        public string? Salutation { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public Guid? RecruitmentTypeId { get; set; }
        public string? RecruitmentType { get; set; }
        public string? AadhaarNumber { get; set; }
        public string? PanNumber { get; set; }
        public string? UanNumber { get; set; }
        public string? EsicNumber { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? AlternatePhoneNumber { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public Guid? GenderId { get; set; }
        public string? Gender { get; set; }
        public string? IdentityMarks { get; set; }
        public bool IsActive { get; set; } = true;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public IFormFile? ProfilePicture { get; set; }

        //public Guid CompanyId { get; set; }
        //public string CompanyName { get; set; } = string.Empty;
        //public string RegistrationId { get; set; } = null!;
        //public Guid? TitleId { get; set; }
        //public string? Salutation { get; set; }
        //public string FirstName { get; set; } = string.Empty;
        //public string? MiddleName { get; set; }
        //public string? LastName { get; set; }
        //public Guid RecruitmentTypeId { get; set; }
        //public string? RecruitmentTypeName { get; set; }
        //public string? AadhaarNumber { get; set; }
        //public string? PanNumber { get; set; }
        //public string? UanNumber { get; set; }
        //public string? EsicNumber { get; set; }
        //public string? Email { get; set; }
        //public string? MobileNumber { get; set; }
        //public string? AlternatePhoneNumber { get; set; }
        //public DateTime? DateOfRegistration { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        //public string? PlaceOfBirth { get; set; }
        //public DateTime? DateOfJoining { get; set; }
        //public Guid? GenderId { get; set; }
        //public string? GenderName { get; set; }
        //public string? IdentityMarks { get; set; }
        //public IFormFile? ProfilePicture { get; set; }
        //public bool IsActive { get; set; }
    }

}
