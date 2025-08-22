using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Query.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, PreviousExperienceDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IPreviousExperienceRepository _previousExperienceRepository;

        public GetByIdQueryHandler(IMapper mapper, IPreviousExperienceRepository previousExperienceRepository)
        {
            _mapper = mapper;
            _previousExperienceRepository = previousExperienceRepository;
        }

        public async Task<PreviousExperienceDetailDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _previousExperienceRepository.GetPreviousExperienceByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.PreviousExperience), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<PreviousExperienceDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
