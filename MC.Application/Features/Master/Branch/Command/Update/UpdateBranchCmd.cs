using MediatR;

namespace MC.Application.Features.Master.Branch.Command.Update
{
    public class UpdateBranchCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int? DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
