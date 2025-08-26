using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Command.Delete
{
    public class DeleteBodyMeasCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
