using MC.Domain.Base;

namespace MC.Domain.Entity.Registration
{
    public class EmployeeReference : BaseEntity
    {
        public Guid UserProfileId { get; set; } // Foreign key to the user profile
        public required UserProfile UserProfile { get; set; } // Navigation property to the user profile
        public string EmployeeName { get; set; } = string.Empty; // Name of the employee
        public string? EmployeeDesignation { get; set; } // Designation of the employee
        public string? EmployeeDepartment { get; set; } // Department of the employee
        public string? EmployeeContactNumber { get; set; } // Contact number of the employee
        public string? EmployeeEmail { get; set; } // Email of the employee
        public string? EmployeeAddress { get; set; } // Address of the employee
        public string? EmployeeRelationship { get; set; } // Relationship with the employee
        public string? Remarks { get; set; } // Additional remarks about the reference
        public bool IsActive { get; set; } = true; // Indicates if the reference is active
    }
}
