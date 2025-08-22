using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.RecruitmentType.Query.GetAll
{
    public record GetAllRecruitmentTypeQuery : IRequest<List<RecruitmentTypeDto>>;
}
