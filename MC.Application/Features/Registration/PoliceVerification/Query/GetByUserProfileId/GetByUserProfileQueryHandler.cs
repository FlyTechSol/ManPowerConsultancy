using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.Features.Registration.PoliceVerification.Query.GetByRegistrationId;
using MC.Application.ModelDto.Registration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Features.Registration.PoliceVerification.Query.GetByUserProfileId
{
    public class GetByUserProfileQueryHandler : IRequestHandler<GetByUserProfileQuery, PoliceVerificationDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IPoliceVerificationRepository _policeVerificationRepository;

        public GetByUserProfileQueryHandler(IMapper mapper, IPoliceVerificationRepository policeVerificationRepository)
        {
            _mapper = mapper;
            _policeVerificationRepository = policeVerificationRepository;
        }

        public async Task<PoliceVerificationDetailDto> Handle(GetByUserProfileQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _policeVerificationRepository.GetPoliceVerificationByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.PoliceVerification), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<PoliceVerificationDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
