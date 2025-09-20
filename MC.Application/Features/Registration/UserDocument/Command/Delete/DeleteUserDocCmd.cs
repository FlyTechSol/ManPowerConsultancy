using MediatR;

namespace MC.Application.Features.Registration.UserDocument.Command.Delete
{
    public class DeleteUserDocCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
