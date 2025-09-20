using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeVerification.Query.GetAll
{
    public class GetAllEmpVeriQueryHandler : IRequestHandler<GetAllEmpVeriQuery, ApiResponse<PaginatedResponse<EmployeeVerificationDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeVerificationRepository _employeeVerificationRepository;

        public GetAllEmpVeriQueryHandler(IMapper mapper, IEmployeeVerificationRepository employeeVerificationRepository)
        {
            _mapper = mapper;
            _employeeVerificationRepository = employeeVerificationRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<EmployeeVerificationDetailDto>>> Handle(GetAllEmpVeriQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _employeeVerificationRepository.GetEmployeeVerificationByUserProfileIdAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<EmployeeVerificationDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
