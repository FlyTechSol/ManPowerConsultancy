using MediatR;

namespace MC.Application.Features.Master.Religion.Command.Delete
{
    public class DeleteReligionCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
