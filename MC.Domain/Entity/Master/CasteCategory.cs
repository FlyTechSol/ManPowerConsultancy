using MC.Domain.Base;

namespace MC.Domain.Entity.Master
{
    public class CasteCategory : BaseEntity
    {
        public string Code { get; set; } = string.Empty; // Code for the caste category
        public string Name { get; set; } = string.Empty; // Description of the caste category
        public int? DisplayOrder { get; set; } // Order of the level, used for sorting
    }
}
