using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.HighestEducation.Query.GetAll
{
    public class GetAllHighestEducationQueryHandler : IRequestHandler<GetAllHighestEducationQuery, ApiResponse<PaginatedResponse<HighestEducationDetailDto>>>
    {
        private readonly IHighestEducationRepository _highestEducationRepository;
        private readonly IAppLogger<GetAllHighestEducationQueryHandler> _logger;

        public GetAllHighestEducationQueryHandler(IHighestEducationRepository highestEducationRepository,
            IAppLogger<GetAllHighestEducationQueryHandler> logger)
        {
            _highestEducationRepository = highestEducationRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<PaginatedResponse<HighestEducationDetailDto>>> Handle(GetAllHighestEducationQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _highestEducationRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);
            return new ApiResponse<PaginatedResponse<HighestEducationDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }       
    }
}
