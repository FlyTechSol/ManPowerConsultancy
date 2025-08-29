using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.Company.Query.GetAll
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, List<CompanyDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly IAppLogger<GetAllCompanyQueryHandler> _logger;

        public GetAllCompanyQueryHandler(IMapper mapper,
            ICompanyRepository companyRepository,
            IAppLogger<GetAllCompanyQueryHandler> logger)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public async Task<List<CompanyDetailDto>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _companyRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<CompanyDetailDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Company were retrieved successfully");
            return data;
        }
    }
}
