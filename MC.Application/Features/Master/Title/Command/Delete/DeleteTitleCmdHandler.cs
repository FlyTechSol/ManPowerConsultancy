using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Title.Command.Delete
{
   public class DeleteTitleCmdHandler : IRequestHandler<DeleteTitleCmd, Unit>
    {
        private readonly ITitleRepository _titleRepository;

        public DeleteTitleCmdHandler(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public async Task<Unit> Handle(DeleteTitleCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var titleToDelete = await _titleRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (titleToDelete == null)
                throw new NotFoundException(nameof(Title), request.Id);

            // remove from database
            await _titleRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
