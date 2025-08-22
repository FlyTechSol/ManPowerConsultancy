namespace MC.Application.ModelDto.Master.Master
{
    public class TitleDto
    {
        public Guid Id { get; set; }
        public int? DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool? IsFemale { get; set; } = false;
        public bool? IsMale { get; set; } = false;
    }
}
