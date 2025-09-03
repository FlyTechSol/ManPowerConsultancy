using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserProfile.Query.GetAll
{
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQuery, ApiResponse<PaginatedResponse<UserProfileDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
      
        public GetAllUserProfilesQueryHandler(IMapper mapper,
            IUserProfileRepository userProfileRepository)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<UserProfileDto>>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _userProfileRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<UserProfileDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
