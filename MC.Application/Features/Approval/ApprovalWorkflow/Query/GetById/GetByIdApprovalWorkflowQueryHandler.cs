using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Approval;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Query.GetById
{
    public class GetByIdApprovalWorkflowQueryHandler : IRequestHandler<GetByIdApprovalWorkflowQuery, ApprovalWorkflowDto>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalWorkflowRepository _approvalWorkflowRepository;

        public GetByIdApprovalWorkflowQueryHandler(IMapper mapper, IApprovalWorkflowRepository approvalWorkflowRepository)
        {
            _mapper = mapper;
            _approvalWorkflowRepository = approvalWorkflowRepository;
        }

        public async Task<ApprovalWorkflowDto> Handle(GetByIdApprovalWorkflowQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _approvalWorkflowRepository.GetApprovalWorkflowByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(ApprovalWorkflow), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<ApprovalWorkflowDto>(record);

            // return DTO object
            return data;
        }
    }
}
