using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Query.GetAllByRegistrationId
{
    public class GetAllByRegistrationIdQueryHandler : IRequestHandler<GetAllByRegistrationIdQuery, PreviousExperienceDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IPreviousExperienceRepository _previousExperienceRepository;

        public GetAllByRegistrationIdQueryHandler(IMapper mapper, IPreviousExperienceRepository previousExperienceRepository)
        {
            _mapper = mapper;
            _previousExperienceRepository = previousExperienceRepository;
        }

        public async Task<PreviousExperienceDetailDto> Handle(GetAllByRegistrationIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _previousExperienceRepository.GetAllPreviousExperienceByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.PreviousExperience), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<PreviousExperienceDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
