using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Query.GetById
{
    public class GetEmpRefByIdQueryHandler : IRequestHandler<GetEmpRefByIdQuery, EmployeeReferenceDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeReferenceRepository _employeeReferenceRepository;

        public GetEmpRefByIdQueryHandler(IMapper mapper, IEmployeeReferenceRepository employeeReferenceRepository)
        {
            _mapper = mapper;
            _employeeReferenceRepository = employeeReferenceRepository;
        }

        public async Task<EmployeeReferenceDetailDto> Handle(GetEmpRefByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _employeeReferenceRepository.GetEmpRefByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.EmployeeReference), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<EmployeeReferenceDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
