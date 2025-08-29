using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Command.Delete
{
    public class DeleteDocumentTypeCmdHandler : IRequestHandler<DeleteDocumentTypeCmd, Unit>
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DeleteDocumentTypeCmdHandler(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        public async Task<Unit> Handle(DeleteDocumentTypeCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _documentTypeRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(DocumentType), request.Id);

            // remove from database
            await _documentTypeRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
