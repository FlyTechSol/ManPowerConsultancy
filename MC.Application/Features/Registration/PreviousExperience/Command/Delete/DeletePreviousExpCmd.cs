using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Command.Delete
{
    public class DeletePreviousExpCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
