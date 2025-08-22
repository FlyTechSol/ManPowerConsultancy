using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.RecruitmentType.Command.Delete
{
   public class DeleteRecruitmentTypeCmdHandler : IRequestHandler<DeleteRecruitmentTypeCmd, Unit>
    {
        private readonly IRecruitmentTypeRepository _recruitmentTypeRepository;

        public DeleteRecruitmentTypeCmdHandler(IRecruitmentTypeRepository recruitmentTypeRepository)
        {
            _recruitmentTypeRepository = recruitmentTypeRepository;
        }

        public async Task<Unit> Handle(DeleteRecruitmentTypeCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _recruitmentTypeRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(RecruitmentType), request.Id);

            // remove from database
            await _recruitmentTypeRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
