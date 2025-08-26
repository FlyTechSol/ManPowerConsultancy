using MediatR;

namespace MC.Application.Features.Master.Asset.Command.Delete
{
    public class DeleteAssetCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
