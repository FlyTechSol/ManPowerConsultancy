using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Query.GetAll
{
    public class GetAllInsNomineeQueryHandler : IRequestHandler<GetAllInsNomineeQuery, ApiResponse<PaginatedResponse<InsuranceNomineeDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceNomineeRepository _insuranceNomineeRepository;

        public GetAllInsNomineeQueryHandler(IMapper mapper, IInsuranceNomineeRepository insuranceNomineeRepository)
        {
            _mapper = mapper;
            _insuranceNomineeRepository = insuranceNomineeRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<InsuranceNomineeDetailDto>>> Handle(GetAllInsNomineeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _insuranceNomineeRepository.GetAllDetailsAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<InsuranceNomineeDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
