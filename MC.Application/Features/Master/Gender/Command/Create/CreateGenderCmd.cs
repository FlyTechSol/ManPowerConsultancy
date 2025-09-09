using MediatR;

namespace MC.Application.Features.Master.Gender.Command.Create
{
    public class CreateGenderCmd : IRequest<Guid>
    {
        public int DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
