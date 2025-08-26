using MediatR;

namespace MC.Application.Features.Master.Religion.Command.Create
{
    public class CreateReligionCmd : IRequest<Guid>
    {
        public int? DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
