using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.ModelDto.Approval
{
    public class ApprovalActionDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid RequestStageId { get; set; }
        public Guid ApproverId { get; set; }
        public string ApproverName { get; set; } = string.Empty; // optional, from User table
        public ActionType Action { get; set; }  // your enum
        public string? Comments { get; set; }
        public DateTime ActionDate { get; set; }
        // Optional: formatted dates for UI
        public string ActionDateDisplay => ActionDate.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
