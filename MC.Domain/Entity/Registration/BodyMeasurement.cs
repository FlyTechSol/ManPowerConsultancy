using MC.Domain.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Domain.Entity.Registration
{
    public class BodyMeasurement : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public double? HeightCm { get; set; }
        public double? WeightKg { get; set; }
        public double? ChestCm { get; set; }
        public double? ShoulderCm { get; set; }
        public HairColour? HairColour { get; set; }
        public EyeColour? EyeColour { get; set; }
        public string? Remark { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
