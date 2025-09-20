using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;


namespace MC.Application.Features.Approval.ApprovalAction.Query.GetAllByApprovalRequest
{
    public class GetAllByApprovalRequestQueryHandler : IRequestHandler<GetAllByApprovalRequestQuery, ApiResponse<PaginatedResponse<ApprovalActionDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalActionRepository _approvalActionRepository;
        public GetAllByApprovalRequestQueryHandler(IMapper mapper,
         IApprovalActionRepository approvalActionRepository)
        {
            _mapper = mapper;
            _approvalActionRepository = approvalActionRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<ApprovalActionDto>>> Handle(GetAllByApprovalRequestQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _approvalActionRepository.GetActionsByRequestIdAsync(request.ApprovalRequestId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<ApprovalActionDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
