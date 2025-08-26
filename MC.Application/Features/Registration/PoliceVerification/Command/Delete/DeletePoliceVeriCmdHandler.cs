using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.PoliceVerification.Command.Delete
{
    public class DeletePoliceVeriCmdHandler : IRequestHandler<DeletePoliceVeriCmd, Unit>
    {
        private readonly IPoliceVerificationRepository _policeVerificationRepository;

        public DeletePoliceVeriCmdHandler(IPoliceVerificationRepository policeVerificationRepository)
        {
            _policeVerificationRepository = policeVerificationRepository;
        }

        public async Task<Unit> Handle(DeletePoliceVeriCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _policeVerificationRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.PoliceVerification), request.Id);

            // remove from database
            await _policeVerificationRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
