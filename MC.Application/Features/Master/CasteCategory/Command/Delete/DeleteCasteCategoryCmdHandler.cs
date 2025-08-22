using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.CasteCategory.Command.Delete
{
    public class DeleteCasteCategoryCmdHandler : IRequestHandler<DeleteCasteCategoryCmd, Unit>
    {
        private readonly ICasteCategoryRepository _casteCategoryRepository;

        public DeleteCasteCategoryCmdHandler(ICasteCategoryRepository casteCategoryRepository)
        {
            _casteCategoryRepository = casteCategoryRepository;
        }

        public async Task<Unit> Handle(DeleteCasteCategoryCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _casteCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(CasteCategory), request.Id);

            // remove from database
            await _casteCategoryRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
