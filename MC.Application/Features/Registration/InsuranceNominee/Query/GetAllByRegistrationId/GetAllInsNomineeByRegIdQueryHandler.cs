using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Query.GetAllByRegistrationId
{
   public class GetAllInsNomineeByRegIdQueryHandler : IRequestHandler<GetAllInsNomineeByRegIdQuery, InsuranceNomineeDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceNomineeRepository _insuranceNomineeRepository;

        public GetAllInsNomineeByRegIdQueryHandler(IMapper mapper, IInsuranceNomineeRepository insuranceNomineeRepository)
        {
            _mapper = mapper;
            _insuranceNomineeRepository = insuranceNomineeRepository;
        }

        public async Task<InsuranceNomineeDetailDto> Handle(GetAllInsNomineeByRegIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _insuranceNomineeRepository.GetAllInsuranceNomineeByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.InsuranceNominee), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<InsuranceNomineeDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
