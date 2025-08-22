using MC.Domain.Base;

namespace MC.Domain.Entity.Master
{
    public class Religion : BaseEntity
    {
        public string Code { get; set; } = string.Empty; // Unique code for the religion
        public string Name { get; set; } = string.Empty; // Name of the religion
        public int? DisplayOrder { get; set; } // Order of the level, used for sorting
    }
}
    