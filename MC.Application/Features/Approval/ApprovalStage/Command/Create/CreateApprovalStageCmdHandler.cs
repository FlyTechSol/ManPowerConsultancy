using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStage.Command.Create
{
    public class CreateApprovalStageCmdHandler : IRequestHandler<CreateApprovalStageCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalStageRepository _approvalStageRepository;

        public CreateApprovalStageCmdHandler(IMapper mapper, IApprovalStageRepository approvalStageRepository)
        {
            _mapper = mapper;
            _approvalStageRepository = approvalStageRepository;
        }

        public async Task<Guid> Handle(CreateApprovalStageCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateApprovalStageCmdValidator(_approvalStageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid approval stage record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Approval.ApprovalStage>(request);

            await _approvalStageRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
