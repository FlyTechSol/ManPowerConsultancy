using MediatR;

namespace MC.Application.Features.Registration.Family.Command.Update
{
    public class UpdateFamilyCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsPFNominee { get; set; } = false;
        public double? PFPercentage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? RelationTo { get; set; }
        public bool IsMinor { get; set; } = false;
        public bool IsDependent { get; set; } = false;
        public bool IsResidingWithEmployee { get; set; } = false;
    }
}
