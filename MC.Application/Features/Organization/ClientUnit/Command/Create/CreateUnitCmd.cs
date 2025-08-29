
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Command.Create
{
    public class CreateUnitCmd : IRequest<Guid>
    {
        public Guid ClientMasterId { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public string UnitLocation { get; set; } = string.Empty;
        public int MaxHeadCount { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
