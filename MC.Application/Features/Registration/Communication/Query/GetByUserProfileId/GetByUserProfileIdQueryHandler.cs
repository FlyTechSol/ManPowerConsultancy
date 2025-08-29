using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Communication.Query.GetByUserProfileId
{
    public class GetByUserProfileIdQueryHandler : IRequestHandler<GetByUserProfileIdQuery, CommunicationDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ICommunicationRepository _communicationRepository;

        public GetByUserProfileIdQueryHandler(IMapper mapper, ICommunicationRepository communicationRepository)
        {
            _mapper = mapper;
            _communicationRepository = communicationRepository;
        }

        public async Task<CommunicationDetailDto> Handle(GetByUserProfileIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _communicationRepository.GetByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Communication), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<CommunicationDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
