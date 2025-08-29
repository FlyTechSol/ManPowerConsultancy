using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Query.GetAll
{
     public record GetAllClientMasterQuery : IRequest<List<ClientMasterDetailDto>>;
}
