using MediatR;

namespace MC.Application.Features.Registration.Resignation.Command.Delete
{
    public class DeleteResignationCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
