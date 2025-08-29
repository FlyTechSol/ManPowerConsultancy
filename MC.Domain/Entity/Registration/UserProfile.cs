using MC.Domain.Base;
using MC.Domain.Entity.Identity;
using MC.Domain.Entity.Master;
using MC.Domain.Entity.Organization;

namespace MC.Domain.Entity.Registration
{
    public class UserProfile : BaseEntity
    {
        public Guid? UserId { get; set; } // Nullable
        public virtual ApplicationUser? User { get; set; } // Optional navigation
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public Guid ClientMasterId { get; set; }
        public ClientMaster ClientMaster { get; set; } = null!;
        public Guid ClientUnitId { get; set; }
        public ClientUnit ClientUnit { get; set; } = null!;
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = null!;
        public Guid DesignationId { get; set; }
        public Designation Designation { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public string RegistrationId { get; set; } = null!; // Unique, non-null
        public Guid? TitleId { get; set; }
        public Title? Salutation { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public Guid? RecruitmentTypeId { get; set; }
        public RecruitmentType? RecruitmentType { get; set; }
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
        public DateTime DateOfJoining { get; set; }
        public Guid? GenderId { get; set; }
        public Gender? Gender { get; set; }
        public string? IdentityMarks { get; set; }
        public bool IsActive { get; set; } = true;

        public string ProfilePictureUrl { get; set; } = string.Empty;
        public BodyMeasurement? BodyMeasurement { get; set; } // optional if not always present
        public Insurance? Insurance { get; set; }
        public Communication? Communication { get; set; }
        public PoliceVerification? PoliceVerifications { get; set; }
        public Resignation? Resignations { get; set; }
        public SecurityDeposit? SecurityDeposit { get; set; }
        public UserGeneralDetail? UserGeneralDetail { get; set; }
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
