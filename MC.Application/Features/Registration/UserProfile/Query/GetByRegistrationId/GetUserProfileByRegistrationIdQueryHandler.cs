using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserProfile.Query.GetByRegistrationId
{
    public class GetUserProfileByRegistrationIdQueryHandler : IRequestHandler<GetUserProfileByRegistrationIdQuery, UserProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;

        public GetUserProfileByRegistrationIdQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<UserProfileDto> Handle(GetUserProfileByRegistrationIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(UserProfile), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<UserProfileDto>(record);

            // return DTO object
            return data;
        }
    }
}
