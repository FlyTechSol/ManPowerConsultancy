using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.HighestEducation.Query.GetAll
{
     public record GetAllHighestEducationQuery : IRequest<List<HighestEducationDto>>;
}
