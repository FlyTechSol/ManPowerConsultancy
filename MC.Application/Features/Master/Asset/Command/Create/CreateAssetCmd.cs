using MediatR;

namespace MC.Application.Features.Master.Asset.Command.Create
{
    public class CreateAssetCmd : IRequest<Guid>
    {
        public int? DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
