using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PoliceVerification.Command.Update
{
    public class UpdatePoliceVeriCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string PoliceStationName { get; set; } = string.Empty;
        public PoliceVerificationStatus VerificationStatus { get; set; }
        public DateTime? VerificationDate { get; set; }
        public string? VerificationRemarks { get; set; }
        public bool IsActive { get; set; }
    }
}
