using MediatR;

namespace MC.Application.Features.Master.HighestEducation.Command.Delete
{
    public class DeleteHighestEducationCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
