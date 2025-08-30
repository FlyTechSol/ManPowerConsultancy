using MediatR;

namespace MC.Application.Features.Master.Category.Command.Delete
{
    public class DeleteCategoryCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
