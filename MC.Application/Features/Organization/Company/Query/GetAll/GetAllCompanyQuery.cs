using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.Company.Query.GetAll
{
   public record GetAllCompanyQuery : IRequest<List<CompanyDetailDto>>;
}
