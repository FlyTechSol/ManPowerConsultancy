using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.Company.Query.GetAll
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, ApiResponse<PaginatedResponse<CompanyDetailDto>>>
    {
        private readonly ICompanyRepository _companyRepository;
      
        public GetAllCompanyQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<ApiResponse<PaginatedResponse<CompanyDetailDto>>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _companyRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);
            return new ApiResponse<PaginatedResponse<CompanyDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
