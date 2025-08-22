namespace MC.Application.ModelDto.Master.Master
{
    public class CountryDto
    {
        public Guid Id { get; set; }
        public int? DisplayOrder { get; set; }
        public string? DialCode { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
