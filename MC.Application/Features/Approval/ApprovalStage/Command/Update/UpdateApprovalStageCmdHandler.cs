using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStage.Command.Update
{
    public class UpdateApprovalStageCmdHandler : IRequestHandler<UpdateApprovalStageCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalStageRepository _approvalStageRepository;

        public UpdateApprovalStageCmdHandler(IMapper mapper, IApprovalStageRepository approvalStageRepository)
        {
            _mapper = mapper;
            _approvalStageRepository = approvalStageRepository;
        }

        public async Task<Unit> Handle(UpdateApprovalStageCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _approvalStageRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateApprovalStageCmdValidator(_approvalStageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid approval stage record", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _approvalStageRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
