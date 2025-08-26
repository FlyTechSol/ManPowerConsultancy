using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PoliceVerification.Query.GetByRegistrationId
{
    public class GetPoliceVeriByRegistrationIdQueryHandler : IRequestHandler<GetPoliceVeriByRegistrationIdQuery, PoliceVerificationDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IPoliceVerificationRepository _policeVerificationRepository;

        public GetPoliceVeriByRegistrationIdQueryHandler(IMapper mapper, IPoliceVerificationRepository policeVerificationRepository)
        {
            _mapper = mapper;
            _policeVerificationRepository = policeVerificationRepository;
        }

        public async Task<PoliceVerificationDetailDto> Handle(GetPoliceVeriByRegistrationIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _policeVerificationRepository.GetPolicleVerificationByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.PoliceVerification), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<PoliceVerificationDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
