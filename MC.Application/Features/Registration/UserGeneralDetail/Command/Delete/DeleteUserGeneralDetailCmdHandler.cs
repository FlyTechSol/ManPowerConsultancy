using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserGeneralDetail.Command.Delete
{
    public class DeleteUserGeneralDetailCmdHandler : IRequestHandler<DeleteUserGeneralDetailCmd, Unit>
    {
        private readonly IUserGeneralDetailRepository _userGeneralDetailRepository;

        public DeleteUserGeneralDetailCmdHandler(IUserGeneralDetailRepository userGeneralDetailRepository)
        {
            _userGeneralDetailRepository = userGeneralDetailRepository;
        }

        public async Task<Unit> Handle(DeleteUserGeneralDetailCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _userGeneralDetailRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.UserGeneralDetail), request.Id);

            // remove from database
            await _userGeneralDetailRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
