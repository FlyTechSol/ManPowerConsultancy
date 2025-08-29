using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Query.GetAll
{
    public record GetAllUnitQuery : IRequest<List<UnitDetailDto>>;
}
