using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Command.Update
{
    public class UpdateClientMasterCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public double ProjectCost { get; set; }
        public string ProjectLocation { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
