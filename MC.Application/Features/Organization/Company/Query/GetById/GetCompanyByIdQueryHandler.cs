using AutoMapper;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.Company.Query.GetById
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public GetCompanyByIdQueryHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDetailDto> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _companyRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(Company), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<CompanyDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
