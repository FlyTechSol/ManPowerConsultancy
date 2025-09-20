using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalAction.Command.Create
{
    public class ApprovalActionCmdHandler : IRequestHandler<ApprovalActionCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalActionRepository _approvalActionRepository;

        public ApprovalActionCmdHandler(IMapper mapper, IApprovalActionRepository approvalActionRepository)
        {
            _mapper = mapper;
            _approvalActionRepository = approvalActionRepository;
        }

        public async Task<Guid> Handle(ApprovalActionCmd request, CancellationToken cancellationToken)
        {
            var validator = new ApprovalActionCmdValidator(_approvalActionRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid approval action record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Approval.ApprovalAction>(request);

            await _approvalActionRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
