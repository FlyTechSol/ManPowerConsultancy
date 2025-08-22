using MC.Domain.Base;
using MC.Domain.Entity.Enum.Registration;
using MC.Domain.Entity.Identity;
using MC.Domain.Entity.Master;

namespace MC.Domain.Entity.Registration
{
    public class UserProfile : BaseEntity
    {
        public Guid UserId { get; set; }
        public required ApplicationUser User { get; set; } // Navigation property to AspNetUsers

        public string RegistrationId { get; set; } = string.Empty; // Unique registration ID  

        // Recruitment type reference
        public Guid RecruitmentTypeId { get; set; }
        public RecruitmentType? RecruitmentType { get; set; }

        // Identification
        public string? AadharNo { get; set; }
        public string? PanNo { get; set; }

        // Name
        public Guid? TitleId { get; set; }
        public Title? Salutation { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        // Contact
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? AlternatePhoneNumber { get; set; }

        // Religion
        public Guid? ReligionId { get; set; }
        public Religion? Religion { get; set; }

        // Nationality
        public Guid? CountryId { get; set; }
        public Country? Nationality { get; set; }

        // Caste Category
        public Guid? CasteCategoryId { get; set; }
        public CasteCategory? CasteCategory { get; set; }

        public bool DifferentlyAbled { get; set; } = false;

        // Education
        public Guid? HighestEducationId { get; set; }
        public HighestEducation? HighestEducation { get; set; }

        // Dates
        public DateTime? DateOfRegistration { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }

        // Gender
        public Guid? GenderId { get; set; }
        public Gender? Gender { get; set; }


        // Marital status
        public MaritalStatus? MaritalStatus { get; set; }  // ✅ Spelling corrected from "MaritialStatus"

        // Family info
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }

        // Employment info
        public string? UanNumber { get; set; }
        public string? EsicNumber { get; set; }

        // Physical identifier
        public string? IdentityMarks { get; set; }
        public bool IsActive { get; set; }
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public BodyMeasurement? BodyMeasurement { get; set; } // optional if not always present
        public Insurance? Insurance { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<ExArmy> ExArmies { get; set; } = new List<ExArmy>();
        public ICollection<UserAsset> UserAssets { get; set; } = new List<UserAsset>();
        public ICollection<EmployeeReference> EmployeeReferences { get; set; } = new List<EmployeeReference>();
        public ICollection<Family> Families { get; set; } = new List<Family>();
        public ICollection<PreviousExperience> PreviousExperiences { get; set; } = new List<PreviousExperience>();
        public ICollection<GunMan> GunMen { get; set; } = new List<GunMan>();
        public ICollection<Training> Trainings { get; set; } = new List<Training>();
        public ICollection<InsuranceNominee> InsuranceNominees { get; set; } = new List<InsuranceNominee>();
    }

}
