using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.CasteCategory.Query.GetAll
{
    public record GetAllCasteCategoryQuery : IRequest<List<CasteCategoryDto>>;
}
