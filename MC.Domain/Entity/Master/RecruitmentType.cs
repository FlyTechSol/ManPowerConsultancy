using MC.Domain.Base;

namespace MC.Domain.Entity.Master
{
    public class RecruitmentType : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? DisplayOrder { get; set; } // Order of the level, used for sorting
    }
}
