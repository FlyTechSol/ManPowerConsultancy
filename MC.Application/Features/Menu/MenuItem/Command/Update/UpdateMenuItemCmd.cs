using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Command.Update
{
    public class UpdateMenuItemCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int MenuItemDisplayOrder { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        //public string Component { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public Guid MenuId { get; set; }
    }
}
