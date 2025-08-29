using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.Company.Query.GetById
{
    public record GetCompanyByIdQuery(Guid Id) : IRequest<CompanyDetailDto>;
}
