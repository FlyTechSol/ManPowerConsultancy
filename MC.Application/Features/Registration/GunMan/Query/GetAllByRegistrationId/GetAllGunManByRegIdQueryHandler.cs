using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.GunMan.Query.GetAllByRegistrationId
{
    public class GetAllGunManByRegIdQueryHandler : IRequestHandler<GetAllGunManByRegIdQuery, List<GunManDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGunManRepository _gunManRepository;

        public GetAllGunManByRegIdQueryHandler(IMapper mapper, IGunManRepository gunManRepository)
        {
            _mapper = mapper;
            _gunManRepository = gunManRepository;
        }

        public async Task<List<GunManDetailDto>> Handle(GetAllGunManByRegIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _gunManRepository.GetAllGunMenByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.GunMan), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<List<GunManDetailDto>>(response);

            // return DTO object
            return data;
        }
    }
}
