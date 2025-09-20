using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeVerification.Query.GetById
{
    public class GetByIdEmpVeriQueryHandler : IRequestHandler<GetByIdEmpVeriQuery, EmployeeVerificationDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeVerificationRepository _employeeVerificationRepository;

        public GetByIdEmpVeriQueryHandler(IMapper mapper, IEmployeeVerificationRepository employeeVerificationRepository)
        {
            _mapper = mapper;
            _employeeVerificationRepository = employeeVerificationRepository;
        }

        public async Task<EmployeeVerificationDetailDto> Handle(GetByIdEmpVeriQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _employeeVerificationRepository.GetEmployeeVerificationByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.ExArmy), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<EmployeeVerificationDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
