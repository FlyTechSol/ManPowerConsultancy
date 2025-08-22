using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Command.Delete
{
    public class DeleteEmpRefCmdHandler : IRequestHandler<DeleteEmpRefCmd, Unit>
    {
        private readonly IEmployeeReferenceRepository _employeeReferenceRepository;

        public DeleteEmpRefCmdHandler(IEmployeeReferenceRepository employeeReferenceRepository)
        {
            _employeeReferenceRepository = employeeReferenceRepository;
        }

        public async Task<Unit> Handle(DeleteEmpRefCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _employeeReferenceRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.EmployeeReference), request.Id);

            // remove from database
            await _employeeReferenceRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
