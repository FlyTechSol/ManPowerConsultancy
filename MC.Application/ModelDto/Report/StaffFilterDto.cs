
namespace MC.Application.ModelDto.Report
{
    public class StaffFilterDto
    {
        public string Query { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 20;
        public string Column { get; set; } = "DateCreated";
        public string Dir { get; set; } = "asc"; // or "desc"

        public Guid? CompanyId { get; set; }
        public Guid? ClientMasterId { get; set; }
        public Guid? ClientUnitId { get; set; }
        public Guid? BarnchId { get; set; }
        public Guid? DesignationId { get; set; }
        public Guid? CategoryId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsExport { get; set; } = false;
    }
}
