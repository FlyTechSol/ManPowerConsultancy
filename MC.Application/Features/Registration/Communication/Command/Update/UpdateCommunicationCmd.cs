using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Communication.Command.Update
{
    public class UpdateCommunicationCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string PersonalMobileNumber { get; set; } = string.Empty;
        public string? OfficialMobileNumber { get; set; }
        public string EmergencyContactNumber { get; set; } = string.Empty;
        public string? LandlineNumber1 { get; set; }
        public string? LandlineNumber2 { get; set; }
        public string? PersonalEmail { get; set; }
        public string? OfficialEmail { get; set; }
        public bool IsActive { get; set; }
    }
}
