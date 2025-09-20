using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Command.UpdateStatus
{
    public class UpdateStatusUserAssetCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsReturned { get; set; } = false;
        public DateTime? ReturnDate { get; set; }
        public ReturnAssetStatus? ReturnStatus { get; set; }
        public string ReturnRemarks { get; set; } = string.Empty;
    }
}

