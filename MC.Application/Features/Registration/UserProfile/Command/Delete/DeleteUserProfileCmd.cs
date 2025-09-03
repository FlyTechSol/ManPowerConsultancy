using MediatR;

namespace MC.Application.Features.Registration.UserProfile.Command.Delete
{
    public class DeleteUserProfileCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
