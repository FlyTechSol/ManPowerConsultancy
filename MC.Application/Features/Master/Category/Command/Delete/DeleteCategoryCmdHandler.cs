using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Category.Command.Delete
{
    public class DeleteCategoryCmdHandler : IRequestHandler<DeleteCategoryCmd, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCmdHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(Category), request.Id);

            // remove from database
            await _categoryRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
