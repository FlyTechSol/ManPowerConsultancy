
namespace MC.Application.ModelDto.Approval
{
    public class PendingApprovalDto
    {
        public Guid RequestId { get; set; }
        public string RequestType { get; set; } = string.Empty;
        public int StageOrder { get; set; }
        public string WorkflowName { get; set; } = string.Empty;
        public string? SubmittedByName { get; set; }
        public DateTime? SubmittedOn { get; set; }
    }
}
