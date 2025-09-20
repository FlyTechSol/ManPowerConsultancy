using MC.Domain.Entity.Enum.Approval;

namespace MC.Persistence.Helper
{
    public static class EnumHelper
    {
        public static string FormatWorkflowType(WorkflowType type) =>
        type switch
        {
            WorkflowType.ProfileApproval => "Profile Approval",
            WorkflowType.LeaveApproval => "Leave Approval",
            WorkflowType.AssetApproval => "Asset Approval",
            WorkflowType.ResignationApproval => "Resignation Approval",
            _ => type.ToString()
        };
    }
}
