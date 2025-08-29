using MediatR;

namespace MC.Application.Features.Master.Branch.Command.Create
{
    public class CreateBranchCmd : IRequest<Guid>
    {
        public int? DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
