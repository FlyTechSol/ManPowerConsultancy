using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.ModelDto.Approval
{
    public class ApprovalRequestStageDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid ApprovalRequestId { get; set; }
        public string ApprovalRequestName { get; set; } = string.Empty;
        public Guid ApprovalStageId { get; set; }
        public string ApprovalStageName { get; set; } = string.Empty;
        public StageStatus Status { get; set; }
    }
}
