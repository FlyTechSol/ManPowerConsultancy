using MediatR;

namespace MC.Application.Features.Master.RecruitmentType.Command.Delete
{
    public class DeleteRecruitmentTypeCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
