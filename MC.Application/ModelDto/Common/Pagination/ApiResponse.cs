
namespace MC.Application.ModelDto.Common.Pagination
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; } = "Success";
        public T? ResData { get; set; }
    }
}
