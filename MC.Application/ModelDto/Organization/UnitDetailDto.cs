using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Organization
{
    public class UnitDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid ClientMasterId { get; set; }
        public string ClientMasterName { get; set; } = null!;
        public string UnitName { get; set; } = string.Empty;
        public string UnitLocation { get; set; } = string.Empty;
        public int MaxHeadCount { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
