using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Query.GetByClientMasterId
{
    public record GetUnitByClientMasterQuery(Guid ClientMasterId): IRequest<List<UnitDetailDto>>;
}
