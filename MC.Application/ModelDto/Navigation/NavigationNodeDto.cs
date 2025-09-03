
using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Navigation
{
    public class NavigationNodeDto :AuditableDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public Guid? ParentId { get; set; }
        public bool IsActive { get; set; }
        public List<NavigationNodeDto> Children { get; set; } = new();
        public List<Guid> RoleIds { get; set; } = new();
    }
}
