using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Command.Update
{
    public class UpdateEmpRefCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string EmployeeName { get; set; } = string.Empty; // Name of the employee
        public string? EmployeeDesignation { get; set; } // Designation of the employee
        public string? EmployeeDepartment { get; set; } // Department of the employee
        public string? EmployeeContactNumber { get; set; } // Contact number of the employee
        public string? EmployeeEmail { get; set; } // Email of the employee
        public string? EmployeeAddress { get; set; } // Address of the employee
        public string? EmployeeRelationship { get; set; } // Relationship with the employee
        public bool IsActive { get; set; } = true; // Indicates if the reference is active
        public string? Remarks { get; set; } // Additional remarks about the reference
    }
}
