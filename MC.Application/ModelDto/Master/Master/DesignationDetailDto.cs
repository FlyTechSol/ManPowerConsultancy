using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Master.Master
{
    public class DesignationDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? DisplayOrder { get; set; }
    }
}
