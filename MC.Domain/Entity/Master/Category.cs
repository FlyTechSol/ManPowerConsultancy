using MC.Domain.Base;

namespace MC.Domain.Entity.Master
{
    public class Category : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? DisplayOrder { get; set; }
    }
}
