using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.ZipCode.Query.GetAll
{
    public class GetAllZipCodeQueryHandler : IRequestHandler<GetAllZipCodeQuery, ApiResponse<PaginatedResponse<ZipCodeDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly IAppLogger<GetAllZipCodeQueryHandler> _logger;

        public GetAllZipCodeQueryHandler(IMapper mapper,
            IZipCodeRepository zipCodeRepository,
            IAppLogger<GetAllZipCodeQueryHandler> logger)
        {
            _mapper = mapper;
            _zipCodeRepository = zipCodeRepository;
            _logger = logger;
        }
        public async Task<ApiResponse<PaginatedResponse<ZipCodeDetailDto>>> Handle(GetAllZipCodeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _zipCodeRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<ZipCodeDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
