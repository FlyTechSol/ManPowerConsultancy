using MediatR;

namespace MC.Application.Features.Registration.Training.Command.Delete
{
    public class DeleteTrainingCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
