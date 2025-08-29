using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Query.GetById
{
    public record GetClientMasterByIdQuery(Guid Id) : IRequest<ClientMasterDetailDto>;
}
