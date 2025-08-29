using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Insurance.Query.GetByUserProfileId
{
   public class GetByUserProfileQueryHandler : IRequestHandler<GetByUserProfileQuery, List<InsuranceDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceRepository _insuranceRepository;

        public GetByUserProfileQueryHandler(IMapper mapper, IInsuranceRepository insuranceRepository)
        {
            _mapper = mapper;
            _insuranceRepository = insuranceRepository;
        }

        public async Task<List<InsuranceDetailDto>> Handle(GetByUserProfileQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _insuranceRepository.GetInsuranceByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Insurance), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<List<InsuranceDetailDto>>(response);

            // return DTO object
            return data;
        }
    }
}
