using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalAction.Query.GetAllByApprovalRequestStage
{
    public class GetAllByApprovalRequestStageQueryHandler : IRequestHandler<GetAllByApprovalRequestStageQuery, ApiResponse<PaginatedResponse<ApprovalActionDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalActionRepository _approvalActionRepository;
        public GetAllByApprovalRequestStageQueryHandler(IMapper mapper,
         IApprovalActionRepository approvalActionRepository)
        {
            _mapper = mapper;
            _approvalActionRepository = approvalActionRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<ApprovalActionDto>>> Handle(GetAllByApprovalRequestStageQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _approvalActionRepository.GetActionsByRequestStageIdAsync(request.ApprovalRequestStageId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<ApprovalActionDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
