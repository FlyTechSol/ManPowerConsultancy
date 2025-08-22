using MediatR;

namespace MC.Application.Features.Master.Title.Command.Update
{
    public class UpdateTitleCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool? IsFemale { get; set; } = false;
        public bool? IsMale { get; set; } = false;
    }
}
