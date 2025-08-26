using MC.Domain.Base;

namespace MC.Domain.Entity.Master
{
    public class AppConfiguration : BaseEntity
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
