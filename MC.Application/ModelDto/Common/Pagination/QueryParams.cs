
namespace MC.Application.ModelDto.Common.Pagination
{
    public class QueryParams
    {
        public string Query { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 20;
        public string Column { get; set; } = "DateCreated";
        public string Dir { get; set; } = "asc"; // or "desc"
    }
}
