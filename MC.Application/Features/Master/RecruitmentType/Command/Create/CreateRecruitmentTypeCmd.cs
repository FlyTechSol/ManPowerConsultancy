using MediatR;

namespace MC.Application.Features.Master.RecruitmentType.Command.Create
{
    public class CreateRecruitmentTypeCmd : IRequest<Guid>
    {
        public int? DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
