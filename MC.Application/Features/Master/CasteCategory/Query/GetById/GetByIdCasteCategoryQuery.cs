using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.CasteCategory.Query.GetById
{
     public record GetByIdCasteCategoryQuery(Guid Id) : IRequest<CasteCategoryDetailDto>;
}
