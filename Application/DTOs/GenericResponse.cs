namespace Application.DTOs
{
    public abstract class BaseResponse(bool status, string message)
    {
        public bool Status { get; set; } = status;
        public string Message { get; set; } = message;
    }

    public class ApiResponse<T>(bool status, string message, T? data = default) : BaseResponse(status, message)
    {
        public T? Data { get; set; } = data;
    }
}
