using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Command.Delete
{
    public class DeleteUnitCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
