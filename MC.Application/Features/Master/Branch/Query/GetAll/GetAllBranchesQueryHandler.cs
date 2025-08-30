using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Branch.Query.GetAll
{
    public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, ApiResponse<PaginatedResponse<BranchDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        private readonly IAppLogger<GetAllBranchesQueryHandler> _logger;

        public GetAllBranchesQueryHandler(IMapper mapper,
            IBranchRepository branchRepository,
            IAppLogger<GetAllBranchesQueryHandler> logger)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<PaginatedResponse<BranchDetailDto>>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _branchRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<BranchDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
