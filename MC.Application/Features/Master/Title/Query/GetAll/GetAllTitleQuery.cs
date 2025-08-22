using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Title.Query.GetAll
{
    public record GetAllTitleQuery : IRequest<List<TitleDto>>
    {
        public bool? IsMale { get; set; }
    }
}
