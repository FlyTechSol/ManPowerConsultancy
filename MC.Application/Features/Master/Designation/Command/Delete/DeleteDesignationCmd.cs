using MediatR;

namespace MC.Application.Features.Master.Designation.Command.Delete
{
    public class DeleteDesignationCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
