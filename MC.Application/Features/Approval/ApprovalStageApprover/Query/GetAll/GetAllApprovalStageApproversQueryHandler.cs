using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Query.GetAll
{
    public class GetAllApprovalStageApproversQueryHandler : IRequestHandler<GetAllApprovalStageApproversQuery, ApiResponse<PaginatedResponse<ApprovalStageApproverDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalStageApproverRepository _approvalStageApproverRepository;
      
        public GetAllApprovalStageApproversQueryHandler(IMapper mapper,
            IApprovalStageApproverRepository approvalStageApproverRepository)
        {
            _mapper = mapper;
            _approvalStageApproverRepository = approvalStageApproverRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<ApprovalStageApproverDto>>> Handle(GetAllApprovalStageApproversQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _approvalStageApproverRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<ApprovalStageApproverDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
