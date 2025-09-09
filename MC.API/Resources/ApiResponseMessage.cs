namespace MC.API.Resources
{
    public class ApiResponseMessage<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ApiResponseMessage<T> SuccessResponse(T? data, string message)
            => new ApiResponseMessage<T> { Success = true, Message = message, Data = data };

        public static ApiResponseMessage<T> FailureResponse(string message)
            => new ApiResponseMessage<T> { Success = false, Message = message };
    }

}
