using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.RecruitmentType.Query.GetById
{
   public record GetByIdRecruitmentTypeQuery(Guid Id) : IRequest<RecruitmentTypeDetailDto>;
}
