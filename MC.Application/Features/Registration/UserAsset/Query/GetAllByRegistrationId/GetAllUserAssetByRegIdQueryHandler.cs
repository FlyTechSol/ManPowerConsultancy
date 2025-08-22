using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Query.GetAllByRegistrationId
{
   public class GetAllUserAssetByRegIdQueryHandler : IRequestHandler<GetAllUserAssetByRegIdQuery, UserAssetDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserAssetRepository _userAssetRepository;

        public GetAllUserAssetByRegIdQueryHandler(IMapper mapper, IUserAssetRepository userAssetRepository)
        {
            _mapper = mapper;
            _userAssetRepository = userAssetRepository;
        }

        public async Task<UserAssetDetailDto> Handle(GetAllUserAssetByRegIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _userAssetRepository.GetAllUserAssetByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.UserAsset), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<UserAssetDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
