using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Command.Delete
{
    public class DeleteClientMasterCmd : IRequest<MediatR.Unit>
    {
        public Guid Id { get; set; }
    }
}
