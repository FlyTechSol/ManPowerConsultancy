using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Registration
{
    public class EmployeeReferenceDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty; // Name of the employee
        public string? EmployeeDesignation { get; set; } // Designation of the employee
        public string? EmployeeDepartment { get; set; } // Department of the employee
        public string? EmployeeContactNumber { get; set; } // Contact number of the employee
        public string? EmployeeEmail { get; set; } // Email of the employee
        public string? EmployeeAddress { get; set; } // Address of the employee
        public string? EmployeeRelationship { get; set; } // Relationship with the employee
        public string? Remarks { get; set; } // Additional remarks about the reference
        public bool IsActive { get; set; }
    }
}
