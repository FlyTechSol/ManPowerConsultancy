using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Query.GetAllByUserProfileId
{
    public class GetAllByUserProfileQueryHandler : IRequestHandler<GetAllByUserProfileQuery, List<PreviousExperienceDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPreviousExperienceRepository _previousExperienceRepository;

        public GetAllByUserProfileQueryHandler(IMapper mapper, IPreviousExperienceRepository previousExperienceRepository)
        {
            _mapper = mapper;
            _previousExperienceRepository = previousExperienceRepository;
        }

        public async Task<List<PreviousExperienceDetailDto>> Handle(GetAllByUserProfileQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _previousExperienceRepository.GetAllPreviousExperienceByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.PreviousExperience), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<List<PreviousExperienceDetailDto>>(response);

            // return DTO object
            return data;
        }
    }
}
