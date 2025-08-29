using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserGeneralDetail.Query.GetByUserProfileId
{
    public class GetUserGeneralByUserProfileIdQueryHandler : IRequestHandler<GetUserGeneralByUserProfileIdQuery, UserGeneralDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserGeneralDetailRepository _userGeneralDetailRepository;

        public GetUserGeneralByUserProfileIdQueryHandler(IMapper mapper, IUserGeneralDetailRepository userGeneralDetailRepository)
        {
            _mapper = mapper;
            _userGeneralDetailRepository = userGeneralDetailRepository;
        }

        public async Task<UserGeneralDetailDto> Handle(GetUserGeneralByUserProfileIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _userGeneralDetailRepository.GetUserGeneralByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.UserGeneralDetail), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<UserGeneralDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
