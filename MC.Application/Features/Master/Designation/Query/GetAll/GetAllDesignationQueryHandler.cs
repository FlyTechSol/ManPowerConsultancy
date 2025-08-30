using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Designation.Query.GetAll
{
    public class GetAllDesignationQueryHandler : IRequestHandler<GetAllDesignationQuery, ApiResponse<PaginatedResponse<DesignationDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IDesignationRepository _designationRepository;
        private readonly IAppLogger<GetAllDesignationQueryHandler> _logger;

        public GetAllDesignationQueryHandler(IMapper mapper,
            IDesignationRepository designationRepository,
            IAppLogger<GetAllDesignationQueryHandler> logger)
        {
            _mapper = mapper;
            _designationRepository = designationRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<PaginatedResponse<DesignationDetailDto>>> Handle(GetAllDesignationQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _designationRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);
            return new ApiResponse<PaginatedResponse<DesignationDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
