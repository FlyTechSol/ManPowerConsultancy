using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Insurance.Query.GetById
{
    public class GetInsuranceByIdQueryHandler : IRequestHandler<GetInsuranceByIdQuery, InsuranceDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceRepository _insuranceRepository;

        public GetInsuranceByIdQueryHandler(IMapper mapper, IInsuranceRepository insuranceRepository)
        {
            _mapper = mapper;
            _insuranceRepository = insuranceRepository;
        }

        public async Task<InsuranceDetailDto> Handle(GetInsuranceByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _insuranceRepository.GetInsuranceByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Insurance), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<InsuranceDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
