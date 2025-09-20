using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Approval;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Query.GetById
{
    public class GetByIdApprovalStageApproverQueryHandler : IRequestHandler<GetByIdApprovalStageApproverQuery, ApprovalStageApproverDto>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalStageApproverRepository _approvalStageApproverRepository;

        public GetByIdApprovalStageApproverQueryHandler(IMapper mapper, IApprovalStageApproverRepository approvalStageApproverRepository)
        {
            _mapper = mapper;
            _approvalStageApproverRepository = approvalStageApproverRepository;
        }

        public async Task<ApprovalStageApproverDto> Handle(GetByIdApprovalStageApproverQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _approvalStageApproverRepository.GetApprovalStageApproverByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(ApprovalStageApprover), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<ApprovalStageApproverDto>(record);

            // return DTO object
            return data;
        }
    }
}
