using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Gender.Query.GetAll
{
    public class GetAllGenderQueryHandler : IRequestHandler<GetAllGenderQuery, ApiResponse<PaginatedResponse<GenderDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        private readonly IAppLogger<GetAllGenderQueryHandler> _logger;

        public GetAllGenderQueryHandler(IMapper mapper,
            IGenderRepository genderRepository,
            IAppLogger<GetAllGenderQueryHandler> logger)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
            _logger = logger;
        }
        public async Task<ApiResponse<PaginatedResponse<GenderDetailDto>>> Handle(GetAllGenderQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _genderRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);
            return new ApiResponse<PaginatedResponse<GenderDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
