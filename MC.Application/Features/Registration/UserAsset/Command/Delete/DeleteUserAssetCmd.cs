using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Command.Delete
{
    public class DeleteUserAssetCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
