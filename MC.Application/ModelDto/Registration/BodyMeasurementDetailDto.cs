using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Registration;
using Microsoft.IdentityModel.Tokens;

namespace MC.Application.ModelDto.Registration
{
    public class BodyMeasurementDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public double? HeightCm { get; set; }
        public double? WeightKg { get; set; }
        public double? ChestCm { get; set; }
        public double? ShoulderCm { get; set; }
        public HairColour? HairColour { get; set; }
        public EyeColour? EyeColour { get; set; }
        public string? Remark { get; set; }
        public bool IsActive { get; set; }
    }
}
