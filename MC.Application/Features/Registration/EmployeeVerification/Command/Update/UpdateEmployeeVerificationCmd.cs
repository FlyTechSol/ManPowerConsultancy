using MC.Domain.Entity.Enum.Registration;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MC.Application.Features.Registration.EmployeeVerification.Command.Update
{
    public class UpdateEmployeeVerificationCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public VerificationType VerificationType { get; set; }
        public string AgencyName { get; set; } = string.Empty;
        public DateTime InitiatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public VerificationStatus Status { get; set; }
        public VerificationResult? Result { get; set; }
        public IFormFile? AgencyReportUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
