using MC.Domain.Entity.Enum.Registration;
using MC.Domain.Entity.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Command.Create
{
    public class CreateEmpRefCmd : IRequest<Guid>
    {
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
