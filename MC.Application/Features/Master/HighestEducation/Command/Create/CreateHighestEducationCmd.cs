using MediatR;

namespace MC.Application.Features.Master.HighestEducation.Command.Create
{
    public class CreateHighestEducationCmd : IRequest<Guid>
    {
        public int? DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
