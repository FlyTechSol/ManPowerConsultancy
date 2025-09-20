using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Command.Create
{
    public class CreateApprovalWorkflowCmdHandler : IRequestHandler<CreateApprovalWorkflowCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalWorkflowRepository _approvalWorkflowRepository;

        public CreateApprovalWorkflowCmdHandler(IMapper mapper, IApprovalWorkflowRepository approvalWorkflowRepository)
        {
            _mapper = mapper;
            _approvalWorkflowRepository = approvalWorkflowRepository;
        }

        public async Task<Guid> Handle(CreateApprovalWorkflowCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateApprovalWorkflowCmdValidator(_approvalWorkflowRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid approval workflow record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Approval.ApprovalWorkflow>(request);

            await _approvalWorkflowRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
