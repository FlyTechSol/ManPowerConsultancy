using MC.Domain.Base;

namespace MC.Domain.Entity.Master
{
    public class ZipCode : BaseEntity
    {
        public string Zipcode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
