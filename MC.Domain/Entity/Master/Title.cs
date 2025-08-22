using MC.Domain.Base;

namespace MC.Domain.Entity.Master
{
    public class Title : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool? IsFemale { get; set; } = false;
        public bool? IsMale { get; set; } = false;
        public int? DisplayOrder { get; set; } // Order of the level, used for sorting
    }
}
