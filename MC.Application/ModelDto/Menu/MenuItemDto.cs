
namespace MC.Application.ModelDto.Menu
{
    public class MenuItemDto
    {
        public Guid Id { get; set; }
        public int MenuItemDisplayOrder { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public Guid MenuId { get; set; }
        public string MenuValue { get; set; } = string.Empty;
    }
}
