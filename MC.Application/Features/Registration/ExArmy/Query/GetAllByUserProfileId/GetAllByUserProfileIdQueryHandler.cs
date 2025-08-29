using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Query.GetAllByUserProfileId
{
    public class GetAllByUserProfileIdQueryHandler : IRequestHandler<GetAllByUserProfileIdQuery, ExArmyDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IExArmyRepository _exArmyRepository;

        public GetAllByUserProfileIdQueryHandler(IMapper mapper, IExArmyRepository exArmyRepository)
        {
            _mapper = mapper;
            _exArmyRepository = exArmyRepository;
        }

        public async Task<ExArmyDetailDto> Handle(GetAllByUserProfileIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _exArmyRepository.GetAllExArmyByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.ExArmy), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<ExArmyDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
