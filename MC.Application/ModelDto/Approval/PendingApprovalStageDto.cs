using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.ModelDto.Approval
{
    public class PendingApprovalStageDto
    {

        public Guid Id { get; set; }
        public string WorkflowName { get; set; } = string.Empty;
        public string RequestedBy { get; set; } = string.Empty;
        public int StageOrder { get; set; }
        public StageStatus StageStatus { get; set; }
    }
}
