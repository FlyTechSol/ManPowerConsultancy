using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Command.Delete
{
    public class DeletePreviousExpCmdHandler : IRequestHandler<DeletePreviousExpCmd, Unit>
    {
        private readonly IPreviousExperienceRepository _previousExperienceRepository;

        public DeletePreviousExpCmdHandler(IPreviousExperienceRepository previousExperienceRepository)
        {
            _previousExperienceRepository = previousExperienceRepository;
        }

        public async Task<Unit> Handle(DeletePreviousExpCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _previousExperienceRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.PreviousExperience), request.Id);

            // remove from database
            await _previousExperienceRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
