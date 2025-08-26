using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Command.Create
{
    public class CreateBodyMeasCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public double? HeightCm { get; set; }
        public double? WeightKg { get; set; }
        public double? ChestCm { get; set; }
        public double? ShoulderCm { get; set; }
        public HairColour? HairColour { get; set; }
        public EyeColour? EyeColour { get; set; }
        public string? Remark { get; set; }
    }
}
