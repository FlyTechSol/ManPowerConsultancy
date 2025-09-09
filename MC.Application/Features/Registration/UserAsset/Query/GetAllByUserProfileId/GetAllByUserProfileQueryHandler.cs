using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Query.GetAllByUserProfileId
{
    public class GetAllByUserProfileQueryHandler : IRequestHandler<GetAllByUserProfileQuery, ApiResponse<PaginatedResponse<UserAssetDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserAssetRepository _userAssetRepository;

        public GetAllByUserProfileQueryHandler(IMapper mapper, IUserAssetRepository userAssetRepository)
        {
            _mapper = mapper;
            _userAssetRepository = userAssetRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<UserAssetDetailDto>>> Handle(GetAllByUserProfileQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _userAssetRepository.GetAllUserAssetByUserProfileIdAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<UserAssetDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
       
}
