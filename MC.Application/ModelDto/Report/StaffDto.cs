using MC.Application.Helper;
using MC.Domain.Entity.Master;

namespace MC.Application.ModelDto.Report
{
    public class StaffDto
    {
        [CsvIgnore]
        public Guid Id { get; set; }

        [CsvColumn("Registration Number", 1)]
        public string RegistrationNumber { get; set; } = string.Empty;

        [CsvColumn("Full Name", 2)]
        public string StaffName { get; set; } = string.Empty;

        [CsvColumn("Gender", 3)]
        public string? Gender { get; set; }

        [CsvColumn("Company", 4)]
        public string Company { get; set; } = string.Empty;

        [CsvColumn("Client Master", 5)]
        public string ClientMaster { get; set; } = string.Empty;

        [CsvColumn("Client Unit", 6)]
        public string ClientUnit { get; set; } = string.Empty;

        [CsvColumn("Branch", 7)]
        public string Branch { get; set; } = string.Empty;

        [CsvColumn("Designation", 8)]
        public string Designation { get; set; } = string.Empty;

        [CsvColumn("Category", 9)]
        public string Category { get; set; } = string.Empty;

        [CsvColumn("Aadhaar", 10)]
        [CsvExcelText]
        public string AadhaarNumber { get; set; } = string.Empty;

        [CsvColumn("PAN Card", 11)]
        public string PanCard { get; set; } = string.Empty;

        [CsvColumn("UAN Number", 12)]
        public string UanNumber { get; set; } = string.Empty;

        [CsvColumn("ESIC Number", 13)]
        public string EsicNumber { get; set; } = string.Empty;

        [CsvColumn("DoB", 14)]
        public string? DateOfBirthDisplay =>
        DateOfBirth.HasValue ? DateOfBirth.Value.ToString("dd-MMM-yyyy") : string.Empty;

        [CsvColumn("DoJ", 15)]
        public string? DateOfJoiningDisplay =>
            DateOfJoining.HasValue ? DateOfJoining.Value.ToString("dd-MMM-yyyy") : string.Empty;

        // keep your original DateOfBirth and DateOfJoining if needed internally
        [CsvIgnore]
        public DateTime? DateOfBirth { get; set; }

        [CsvIgnore]
        public DateTime? DateOfJoining { get; set; }

        [CsvColumn("Email", 16)]
        public string? Email { get; set; }

        [CsvColumn("Mobile", 17)]
        [CsvExcelText]
        public string? Mobile { get; set; }

        [CsvColumn("Is Active", 18)]
        public bool IsActive { get; set; } = false;

        [CsvColumn("Father", 19)]
        public string? FatherName { get; set; }

        [CsvColumn("Mother", 20)]
        public string? MotherName { get; set; }

        [CsvColumn("Spouse", 21)]
        public string? SpouseName { get; set; }

        [CsvColumn("Religion", 22)]
        public string? Religion { get; set; }

        [CsvColumn("Nationality", 23)]
        public string? Nationality { get; set; }

        [CsvColumn("Caste", 24)]
        public string? CasteCategory { get; set; }

        [CsvColumn("Is Differently Abled", 25)]
        public bool DifferentlyAbled { get; set; } = false;

        [CsvColumn("Highest Education", 26)]
        public string? HighestEducation { get; set; }

        [CsvColumn("Marital Status", 27)]
        public string? MaritalStatus { get; set; }
    }
}
