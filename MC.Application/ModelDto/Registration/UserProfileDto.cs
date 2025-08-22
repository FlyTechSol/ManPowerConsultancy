namespace MC.Application.ModelDto.Registration
{
    public class UserProfileDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string RegistrationId { get; set; } = string.Empty;

        public Guid RecruitmentTypeId { get; set; }
        public string? RecruitmentTypeName { get; set; }

        public string? AadharNo { get; set; }

        public Guid? TitleId { get; set; }
        public string? Salutation { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? AlternatePhoneNumber { get; set; }

        public Guid? ReligionId { get; set; }
        public string? ReligionName { get; set; }

        public Guid? CountryId { get; set; }
        public string? NationalityName { get; set; }

        public Guid? CasteCategoryId { get; set; }
        public string? CasteCategoryName { get; set; }

        public bool DifferentlyAbled { get; set; }

        public Guid? HighestEducationId { get; set; }
        public string? HighestEducationName { get; set; }

        public DateTime? DateOfRegistration { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }

        public Guid? GenderId { get; set; }
        public string? GenderName { get; set; }

        public string? MaritalStatus { get; set; } // Stored as string in DB

        public string? FatherName { get; set; }
        public string? MotherName { get; set; }

        public string? UanNumber { get; set; }
        public string? EsicNumber { get; set; }

        public string? IdentityMarks { get; set; }
    }

}
