using MediatR;

namespace MC.Application.Features.Registration.EmployeeVerification.Command.Delete
{
    public class DeleteEmployeeVerificationCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
