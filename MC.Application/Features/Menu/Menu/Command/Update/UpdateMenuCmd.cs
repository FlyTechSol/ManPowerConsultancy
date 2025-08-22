using MediatR;

namespace MC.Application.Features.Menu.Menu.Command.Update
{
    public class UpdateMenuCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int MenuDisplayOrder { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsParent { get; set; }
        public string NavigationURL { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public string Component { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
    }
}
