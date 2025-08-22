using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Gender.Query.GetById
{
   public record GetByIdGenderQuery(Guid Id) : IRequest<GenderDetailDto>;
}
