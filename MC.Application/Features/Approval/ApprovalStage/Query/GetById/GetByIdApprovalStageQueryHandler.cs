using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Approval;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStage.Query.GetById
{
    public class GetByIdApprovalStageQueryHandler : IRequestHandler<GetByIdApprovalStageQuery, ApprovalStagesDto>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalStageRepository _approvalStageRepository;

        public GetByIdApprovalStageQueryHandler(IMapper mapper, IApprovalStageRepository approvalStageRepository)
        {
            _mapper = mapper;
            _approvalStageRepository = approvalStageRepository;
        }

        public async Task<ApprovalStagesDto> Handle(GetByIdApprovalStageQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _approvalStageRepository.GetApprovalStageByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(ApprovalStage), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<ApprovalStagesDto>(record);

            // return DTO object
            return data;
        }
    }
}
