using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Query.GetAllByUserProfileId
{
    public class GetAllByUserProfileQueryHandler : IRequestHandler<GetAllByUserProfileQuery, List<InsuranceNomineeDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceNomineeRepository _insuranceNomineeRepository;

        public GetAllByUserProfileQueryHandler(IMapper mapper, IInsuranceNomineeRepository insuranceNomineeRepository)
        {
            _mapper = mapper;
            _insuranceNomineeRepository = insuranceNomineeRepository;
        }

        public async Task<List<InsuranceNomineeDetailDto>> Handle(GetAllByUserProfileQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _insuranceNomineeRepository.GetAllInsuranceNomineeByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.InsuranceNominee), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<List<InsuranceNomineeDetailDto>>(response);

            // return DTO object
            return data;
        }
    }
}
