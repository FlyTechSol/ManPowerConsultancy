using MediatR;

namespace MC.Application.Features.Master.Gender.Command.Update
{
    public class UpdateGenderCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
