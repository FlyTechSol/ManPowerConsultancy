using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Designation.Command.Delete
{
   public class DeleteDesignationCmdHandler : IRequestHandler<DeleteDesignationCmd, Unit>
    {
        private readonly IDesignationRepository _designationRepository;

        public DeleteDesignationCmdHandler(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }

        public async Task<Unit> Handle(DeleteDesignationCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _designationRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(Designation), request.Id);

            // remove from database
            await _designationRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
