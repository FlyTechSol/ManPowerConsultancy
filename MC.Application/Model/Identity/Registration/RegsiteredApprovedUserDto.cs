
namespace MC.Application.Model.Identity.Registration
{
    public class RegsiteredApprovedUserDto
    {
        public Guid Id { get; set; }
        public Guid? TitleId { get; set; }
        public string? Title { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public Guid? DesignationId { get; set; }
        public string? Designation { get; set; }
        public Guid? CompanyId { get; set; }
        public string? Company { get; set; }
    }
}
