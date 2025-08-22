using MC.Domain.Base;

namespace MC.Domain.Entity.Master
{
    public class Country : BaseEntity
    {
        public string Code { get; set; } = string.Empty; // ISO code of the country
        public string Name { get; set; } = string.Empty; // Name of the country
        public string? DialCode { get; set; } // Dial code for phone numbers in this country
        public int? DisplayOrder { get; set; } // Order of the level, used for sorting
    }
}
