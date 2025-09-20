using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeVerification.Command.Create
{
    public class CreateEmployeeVerificationCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public VerificationType VerificationType { get; set; }
        public string AgencyName { get; set; } = string.Empty;
        public DateTime InitiatedDate { get; set; }
        public VerificationStatus Status { get; set; }
    }
}
