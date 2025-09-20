using MediatR;

namespace MC.Application.Features.Organization.Company.Command.Create
{
    public class CreateCompanyCmd : IRequest<Guid>
    {
        public string CompanyName { get; set; } = null!;
        public string? LegalName { get; set; } 
        public string? RegistrationNumber { get; set; } 
        public string? CompanyPan { get; set; } 
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public bool IsActive { get; set; } = true;
        //for staff registration Id
        public int LastRegistrationId { get; set; }
        public string RegistrationPrefix { get; set; } =string.Empty;
    }
}
