using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Religion.Query.GetAll
{
    public class GetAllReligionQueryHandler : IRequestHandler<GetAllReligionQuery, ApiResponse<PaginatedResponse<ReligionDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IReligionRepository _religionRepository;
        private readonly IAppLogger<GetAllReligionQueryHandler> _logger;

        public GetAllReligionQueryHandler(IMapper mapper,
            IReligionRepository religionRepository,
            IAppLogger<GetAllReligionQueryHandler> logger)
        {
            _mapper = mapper;
            _religionRepository = religionRepository;
            _logger = logger;
        }
        public async Task<ApiResponse<PaginatedResponse<ReligionDetailDto>>> Handle(GetAllReligionQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _religionRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<ReligionDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
