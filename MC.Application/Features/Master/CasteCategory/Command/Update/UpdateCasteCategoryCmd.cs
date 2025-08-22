using MediatR;

namespace MC.Application.Features.Master.CasteCategory.Command.Update
{
    public class UpdateCasteCategoryCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int? DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
