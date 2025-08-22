using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Family.Command.Delete
{
    public class DeleteFamilyCmdHandler : IRequestHandler<DeleteFamilyCmd, Unit>
    {
        private readonly IFamilyRepository _familyRepository;

        public DeleteFamilyCmdHandler(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        public async Task<Unit> Handle(DeleteFamilyCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _familyRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Family), request.Id);

            // remove from database
            await _familyRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
