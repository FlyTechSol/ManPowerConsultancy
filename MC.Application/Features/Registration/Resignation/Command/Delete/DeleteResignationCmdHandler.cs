using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Resignation.Command.Delete
{
    public class DeleteResignationCmdHandler : IRequestHandler<DeleteResignationCmd, Unit>
    {
        private readonly IResignationRepository _resignationRepository;

        public DeleteResignationCmdHandler(IResignationRepository resignationRepository)
        {
            _resignationRepository = resignationRepository;
        }

        public async Task<Unit> Handle(DeleteResignationCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _resignationRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Resignation), request.Id);

            // remove from database
            await _resignationRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
