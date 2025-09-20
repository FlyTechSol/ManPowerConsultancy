using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeVerification.Command.Delete
{
    public class DeleteEmployeeVerificationCmdHandler : IRequestHandler<DeleteEmployeeVerificationCmd, Unit>
    {
        private readonly IEmployeeVerificationRepository _employeeVerificationRepository;

        public DeleteEmployeeVerificationCmdHandler(IEmployeeVerificationRepository employeeVerificationRepository)
        {
            _employeeVerificationRepository = employeeVerificationRepository;
        }

        public async Task<Unit> Handle(DeleteEmployeeVerificationCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _employeeVerificationRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.EmployeeVerification), request.Id);

            // remove from database
            await _employeeVerificationRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
