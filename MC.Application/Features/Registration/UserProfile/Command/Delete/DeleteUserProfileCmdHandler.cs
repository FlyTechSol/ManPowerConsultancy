using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserProfile.Command.Delete
{
    public class DeleteUserProfileCmdHandler : IRequestHandler<DeleteUserProfileCmd, Unit>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public DeleteUserProfileCmdHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<Unit> Handle(DeleteUserProfileCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _userProfileRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.UserProfile), request.Id);

            // remove from database
            await _userProfileRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
