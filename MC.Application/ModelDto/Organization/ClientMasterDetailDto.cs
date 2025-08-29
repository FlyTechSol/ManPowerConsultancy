using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Organization
{
    public class ClientMasterDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string ClientName { get; set; } = string.Empty;
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public double ProjectCost { get; set; }
        public string ProjectLocation { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
