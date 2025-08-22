using MediatR;

namespace MC.Application.Features.Master.CasteCategory.Command.Delete
{
    public class DeleteCasteCategoryCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
