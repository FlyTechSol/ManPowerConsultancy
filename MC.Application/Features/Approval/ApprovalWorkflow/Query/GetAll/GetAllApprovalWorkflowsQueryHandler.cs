using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Query.GetAll
{
    public class GetAllApprovalWorkflowsQueryHandler : IRequestHandler<GetAllApprovalWorkflowsQuery, ApiResponse<PaginatedResponse<ApprovalWorkflowDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalWorkflowRepository _approvalWorkflowRepository;
       
        public GetAllApprovalWorkflowsQueryHandler(IMapper mapper,
            IApprovalWorkflowRepository approvalWorkflowRepository)
        {
            _mapper = mapper;
            _approvalWorkflowRepository = approvalWorkflowRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<ApprovalWorkflowDto>>> Handle(GetAllApprovalWorkflowsQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _approvalWorkflowRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<ApprovalWorkflowDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
