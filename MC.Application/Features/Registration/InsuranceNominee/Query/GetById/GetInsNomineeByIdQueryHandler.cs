using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Query.GetById
{
    public class GetInsNomineeByIdQueryHandler : IRequestHandler<GetInsNomineeByIdQuery, InsuranceNomineeDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceNomineeRepository _insuranceNomineeRepository;

        public GetInsNomineeByIdQueryHandler(IMapper mapper, IInsuranceNomineeRepository insuranceNomineeRepository)
        {
            _mapper = mapper;
            _insuranceNomineeRepository = insuranceNomineeRepository;
        }

        public async Task<InsuranceNomineeDetailDto> Handle(GetInsNomineeByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _insuranceNomineeRepository.GetInsuranceNomineeByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.InsuranceNominee), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<InsuranceNomineeDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
