using MediatR;

namespace MC.Application.Features.Master.Branch.Command.Delete
{
    public class DeleteBranchCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
