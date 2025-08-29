using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Query.GetById
{
    public record GetUnitByIdQuery(Guid Id) : IRequest<UnitDetailDto>;
}
