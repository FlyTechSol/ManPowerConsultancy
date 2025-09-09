using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Query.GetAll
{
    public class GetAllEmpRefQueryHandler : IRequestHandler<GetAllEmpRefQuery, ApiResponse<PaginatedResponse<EmployeeReferenceDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeReferenceRepository _employeeReferenceRepository;

        public GetAllEmpRefQueryHandler(IMapper mapper, IEmployeeReferenceRepository employeeReferenceRepository)
        {
            _mapper = mapper;
            _employeeReferenceRepository = employeeReferenceRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<EmployeeReferenceDetailDto>>> Handle(GetAllEmpRefQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _employeeReferenceRepository.GetAllEmployeesByUserProfileIdAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<EmployeeReferenceDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
