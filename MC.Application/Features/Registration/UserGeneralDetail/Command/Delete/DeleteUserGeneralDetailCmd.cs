using MediatR;

namespace MC.Application.Features.Registration.UserGeneralDetail.Command.Delete
{
    public class DeleteUserGeneralDetailCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
