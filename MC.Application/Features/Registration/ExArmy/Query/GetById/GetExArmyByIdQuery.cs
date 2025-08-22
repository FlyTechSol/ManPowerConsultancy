using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Query.GetById
{
    public record GetExArmyByIdQuery(Guid Id) : IRequest<ExArmyDetailDto>;
}
