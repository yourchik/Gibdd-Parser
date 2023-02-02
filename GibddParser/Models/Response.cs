namespace GibddParser.Models;

public class Response<T>
{
    public Response(bool success, string message, T result)
    {
        Success = success;
        Message = message;
        Result = result;
    }
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Result { get; set; }
}




