using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Master.Master
{
    public class ZipCodeDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public string Zipcode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
