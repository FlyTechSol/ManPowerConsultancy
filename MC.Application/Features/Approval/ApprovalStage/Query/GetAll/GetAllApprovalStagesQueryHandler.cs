using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStage.Query.GetAll
{
    public class GetAllApprovalStagesQueryHandler : IRequestHandler<GetAllApprovalStagesQuery, ApiResponse<PaginatedResponse<ApprovalStagesDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalStageRepository _approvalStageRepository;
     
        public GetAllApprovalStagesQueryHandler(IMapper mapper,
            IApprovalStageRepository approvalStageRepository)
        {
            _mapper = mapper;
            _approvalStageRepository = approvalStageRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<ApprovalStagesDto>>> Handle(GetAllApprovalStagesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _approvalStageRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<ApprovalStagesDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
