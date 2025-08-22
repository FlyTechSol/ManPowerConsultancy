using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Command.Delete
{
    public class DeleteEmpRefCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
