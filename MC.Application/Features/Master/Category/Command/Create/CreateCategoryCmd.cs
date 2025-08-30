using MediatR;

namespace MC.Application.Features.Master.Category.Command.Create
{
    public class CreateCategoryCmd : IRequest<Guid>
    {
        public int? DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
