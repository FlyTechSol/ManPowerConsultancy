using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Query.GetByCompanyId
{
   public record GetClientMasterByCompanyIdQuery(Guid CompanyId) : IRequest<List<ClientMasterDetailDto>>;
}
