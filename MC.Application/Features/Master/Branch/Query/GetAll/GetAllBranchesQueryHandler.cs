using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Branch.Query.GetAll
{
    public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, List<BranchDetailDto>>
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

        public async Task<List<BranchDetailDto>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _branchRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<BranchDetailDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Branch were retrieved successfully");
            return data;
        }
    }
}
