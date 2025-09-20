using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserDocument.Command.Delete
{
    public class DeleteUserDocCmdHandler : IRequestHandler<DeleteUserDocCmd, Unit>
    {
        private readonly IUserDocumentRepository _userDocumentRepository;

        public DeleteUserDocCmdHandler(IUserDocumentRepository userDocumentRepository)
        {
            _userDocumentRepository = userDocumentRepository;
        }

        public async Task<Unit> Handle(DeleteUserDocCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _userDocumentRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.UserDocument), request.Id);

            // remove from database
            await _userDocumentRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
