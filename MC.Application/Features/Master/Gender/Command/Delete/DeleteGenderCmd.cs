using MediatR;

namespace MC.Application.Features.Master.Gender.Command.Delete
{
    public class DeleteGenderCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
