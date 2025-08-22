using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.EmployeeReference.Command.Update
{
    public class UpdateEmpRefCmdValidator : AbstractValidator<UpdateEmpRefCmd>
    {
        private readonly IEmployeeReferenceRepository _employeeReferenceRepository;

        public UpdateEmpRefCmdValidator(IEmployeeReferenceRepository employeeReferenceRepository)
        {
            _employeeReferenceRepository = employeeReferenceRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.EmployeeName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.EmployeeDesignation)
                .MaximumLength(80).WithMessage("{PropertyName} must be fewer than 80 characters");

            RuleFor(p => p.EmployeeDepartment)
                .MaximumLength(80).WithMessage("{PropertyName} must be fewer than 80 characters");

            RuleFor(p => p.EmployeeContactNumber)
                .MaximumLength(15).WithMessage("{PropertyName} must be fewer than 15 characters");

            RuleFor(p => p.EmployeeEmail)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.EmployeeAddress)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(p => p.EmployeeRelationship)
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.Remarks)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _employeeReferenceRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
