using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Query.GetAllByUserProfileId
{
    public class GetAllByUserProfileQueryHandler : IRequestHandler<GetAllByUserProfileQuery, List<UserAssetDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserAssetRepository _userAssetRepository;

        public GetAllByUserProfileQueryHandler(IMapper mapper, IUserAssetRepository userAssetRepository)
        {
            _mapper = mapper;
            _userAssetRepository = userAssetRepository;
        }

        public async Task<List<UserAssetDetailDto>> Handle(GetAllByUserProfileQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _userAssetRepository.GetAllUserAssetByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.UserAsset), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<List<UserAssetDetailDto>>(response);

            // return DTO object
            return data;
        }
    }
}
