using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Query.GetAllByRegistrationId
{
    public class GetAllEmpRefByRegistrationIdQueryHandler : IRequestHandler<GetAllEmpRefByRegistrationIdQuery, EmployeeReferenceDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeReferenceRepository _employeeReferenceRepository;

        public GetAllEmpRefByRegistrationIdQueryHandler(IMapper mapper, IEmployeeReferenceRepository employeeReferenceRepository)
        {
            _mapper = mapper;
            _employeeReferenceRepository = employeeReferenceRepository;
        }

        public async Task<EmployeeReferenceDetailDto> Handle(GetAllEmpRefByRegistrationIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _employeeReferenceRepository.GetAllEmpRefByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.EmployeeReference), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<EmployeeReferenceDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
