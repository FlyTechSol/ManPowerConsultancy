using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Approval
{
    public class ApprovalStageApproverDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid ApprovalStageId { get; set; }
        public string ApprovalStageName { get; set; } = string.Empty;
        public Guid? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public Guid? RoleId { get; set; }
        public string? RoleName { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool IsMandatory { get; set; }
    }
}
