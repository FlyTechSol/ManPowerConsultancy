using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.GunMan.Query.GetAllByUserProfileId
{
    public class GetAllByUserProfileQueryHandler : IRequestHandler<GetAllByUserProfileQuery, List<GunManDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGunManRepository _gunManRepository;

        public GetAllByUserProfileQueryHandler(IMapper mapper, IGunManRepository gunManRepository)
        {
            _mapper = mapper;
            _gunManRepository = gunManRepository;
        }

        public async Task<List<GunManDetailDto>> Handle(GetAllByUserProfileQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _gunManRepository.GetAllGunMenByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.GunMan), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<List<GunManDetailDto>>(response);

            // return DTO object
            return data;
        }
    }
}
