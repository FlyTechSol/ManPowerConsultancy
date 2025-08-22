using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Gender.Query.GetAll
{
    public record GetAllGenderQuery : IRequest<List<GenderDto>>;
}
