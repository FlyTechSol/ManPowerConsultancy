using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Registration
{
    public class ResignationDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public DateTime ResignationDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        //public bool IsActive { get; set; }
    }
}

