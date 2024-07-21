namespace DesafioUbc.Application.Responses;

public class Response<T>
{
    public bool IsValid { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public Response(T? data, bool isValid = true, string? message = null)
    {
        Data = data;
        IsValid = isValid;
        Message = message;
    }
}