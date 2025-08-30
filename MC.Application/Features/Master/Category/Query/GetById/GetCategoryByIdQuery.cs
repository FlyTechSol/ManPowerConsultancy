using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Category.Query.GetById
{
   public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDetailDto>;
}
