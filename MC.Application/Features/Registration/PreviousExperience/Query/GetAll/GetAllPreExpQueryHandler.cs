using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Query.GetAll
{
    public class GetAllPreExpQueryHandler : IRequestHandler<GetAllPreExpQuery, ApiResponse<PaginatedResponse<PreviousExperienceDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IPreviousExperienceRepository _previousExperienceRepository;

        public GetAllPreExpQueryHandler(IMapper mapper, IPreviousExperienceRepository previousExperienceRepository)
        {
            _mapper = mapper;
            _previousExperienceRepository = previousExperienceRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<PreviousExperienceDetailDto>>> Handle(GetAllPreExpQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _previousExperienceRepository.GetAllDetailsAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<PreviousExperienceDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
