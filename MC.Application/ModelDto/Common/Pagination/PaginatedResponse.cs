
namespace MC.Application.ModelDto.Common.Pagination
{
    public class PaginatedResponse<T>
    {
        public List<T> Data { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
