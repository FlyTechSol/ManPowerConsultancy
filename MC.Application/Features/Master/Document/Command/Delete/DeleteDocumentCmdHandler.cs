using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Document.Command.Delete
{
    public class DeleteDocumentCmdHandler : IRequestHandler<DeleteDocumentCmd, Unit>
    {
        private readonly IDocumentRepository _documentRepository;

        public DeleteDocumentCmdHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<Unit> Handle(DeleteDocumentCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _documentRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(Document), request.Id);

            // remove from database
            await _documentRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
