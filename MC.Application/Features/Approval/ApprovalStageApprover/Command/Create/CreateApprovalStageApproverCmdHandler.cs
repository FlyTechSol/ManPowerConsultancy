using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Command.Create
{
    public class CreateApprovalStageApproverCmdHandler : IRequestHandler<CreateApprovalStageApproverCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalStageApproverRepository _approvalStageApproverRepository;

        public CreateApprovalStageApproverCmdHandler(IMapper mapper, IApprovalStageApproverRepository approvalStageApproverRepository)
        {
            _mapper = mapper;
            _approvalStageApproverRepository = approvalStageApproverRepository;
        }

        public async Task<Guid> Handle(CreateApprovalStageApproverCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateApprovalStageApproverCmdValidator(_approvalStageApproverRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid approval stage approver record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Approval.ApprovalStageApprover>(request);

            await _approvalStageApproverRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
