using MediatR;

namespace MC.Application.Features.Master.Category.Command.Update
{
    public class UpdateCategoryCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int? DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
