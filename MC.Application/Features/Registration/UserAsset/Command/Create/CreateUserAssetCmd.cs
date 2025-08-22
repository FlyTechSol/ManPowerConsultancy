using MC.Domain.Entity.Enum.Registration;
using MC.Domain.Entity.Master;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Command.Create
{
    public class CreateUserAssetCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public Guid AssetId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string SerialNo { get; set; } = string.Empty;
        public decimal AssetValue { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; } = string.Empty; // Additional information about the asset
        public bool IsReturnable { get; set; } = true;
        public bool IsReturned { get; set; } = false;
        public DateTime? ReturnDate { get; set; }
        public ReturnAssetStatus ReturnStatus { get; set; }
    }
}
