using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Religion.Query.GetAll
{
  public record GetAllReligionQuery : IRequest<List<ReligionDto>>;
}
